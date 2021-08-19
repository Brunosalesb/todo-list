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
            services.AddControllers();
            services.AddApiVersioning();
            services.AddCors();

            services.AddResponseCompression(opt =>
            {
                opt.Providers.Add<GzipCompressionProvider>();
                opt.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });

            ConfigureDataContext(services);

            ConfigureAppServiceDependencyInjection(services);

            ConfigureRepositoryDependencyInjection(services);

            services.AddSwaggerGen();
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

            ConfigureSwagger(app);
        }

        public void ConfigureAppServiceDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IToDoAppService, ToDoAppService>();
        }

        public void ConfigureRepositoryDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IToDoRepository, ToDoRepository>();
        }

        public void ConfigureDataContext(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));
        }

        public void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
