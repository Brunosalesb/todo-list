using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using ToDoList.Infra.Contexts;

namespace ToDoList.Api
{
    public class Startup
    {
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

            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(@"Server=localhost,1433;Database=ToDo;User Id=SA;Password=1q2w3e4r@#$;"));

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
