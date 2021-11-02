using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.AppService;
using ToDoList.Data.Repositories;
using ToDoList.Data.Transactions;
using ToDoList.Domain.Shared.Transactions;
using ToDoList.Domain.SqlServer.Contracts.Request;
using ToDoList.Domain.SqlServer.Interfaces;
using ToDoList.Domain.SqlServer.Validators;

namespace ToDoList.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            #region Repository

            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region AppService

            services.AddScoped<IToDoAppService, ToDoAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

            #endregion

            #region Validator

            services.AddScoped<IValidator<CreateToDoRequest>, CreateToDoRequestValidator>();
            services.AddScoped<IValidator<UpdateToDoRequest>, UpdateToDoRequestValidator>();

            #endregion

            #region Others

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            #endregion
        }
    }
}
