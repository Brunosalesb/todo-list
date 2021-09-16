using System.Threading.Tasks;
using ToDoList.Domain.Helpers;
using ToDoList.Domain.Shared;
using ToDoList.Domain.Shared.Enums;
using ToDoList.Domain.SqlServer.Contracts.Request.User;
using ToDoList.Domain.SqlServer.Entities;
using ToDoList.Domain.SqlServer.Interfaces;

namespace ToDoList.AppService
{
    public class UserAppService : BaseService, IUserAppService
    {
        private readonly IUserRepository _repository;

        public UserAppService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultData> Post(CreateUserRequest request)
        {
            var user = new User(request.Email, request.Password);
            await _repository.Create(user);
            return SuccessData(EGenericOperations.Record_Saved_Successfully.GetDescription());
        }
    }
}
