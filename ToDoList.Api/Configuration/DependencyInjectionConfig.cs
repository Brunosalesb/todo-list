using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.AppService;
using ToDoList.Domain.SqlServer.Contracts.Request;
using ToDoList.Domain.SqlServer.Interfaces;
using ToDoList.Domain.SqlServer.Validators;
using ToDoList.Infra.Repositories;

namespace ToDoList.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<IToDoRepository, ToDoRepository>();
            #endregion
            services.AddScoped<IToDoAppService, ToDoAppService>();

            services.AddScoped<IValidator<CreateToDoRequest>, CreateToDoRequestValidator>();
        }
    }
}
