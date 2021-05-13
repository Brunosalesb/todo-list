using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using ToDoList.AppService;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Contexts;
using ToDoList.Infra.Repositories;

namespace ToDoList.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //evitar problemas com CrossOrigin
            services.AddCors();

            //comprimir JSON antes de enviar para a tela
            services.AddResponseCompression(opt =>
            {
                opt.Providers.Add<GzipCompressionProvider>();
                opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            //services.AddDbContext<DataContext>(opt => opt.UseSqlServer(@"Server=localhost,1433;Database=ToDo;User Id=SA;Password=1q2w3e4r@#$;"));
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            //AddScoped garante que só tem 1 dataContext por requisicao, e quando a requisicao acaba, trata de destruir o dataContext, assim destruindo a conexao com o banco de dados
            services.AddScoped<IToDoAppService, ToDoAppService>();
            services.AddScoped<IToDoRepository, ToDoRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //forçar api responder sobre https
            app.UseHttpsRedirection();

            //utilizar roteamento
            app.UseRouting();

            //chamadas localhost
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //mapeamento dos endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
