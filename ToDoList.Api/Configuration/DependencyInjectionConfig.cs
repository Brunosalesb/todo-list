using Microsoft.Extensions.DependencyInjection;
using ToDoList.AppService;
using ToDoList.Domain.SqlServer.Interfaces;
using ToDoList.Infra.Repositories;

namespace ToDoList.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IToDoAppService, ToDoAppService>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
        }
    }
}
