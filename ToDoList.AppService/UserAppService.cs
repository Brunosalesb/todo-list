using System.Threading.Tasks;
using ToDoList.Domain.Helpers;
using ToDoList.Domain.Shared;
using ToDoList.Domain.Shared.Enums;
using ToDoList.Domain.Shared.Transactions;
using ToDoList.Domain.SqlServer.Contracts.Request.User;
using ToDoList.Domain.SqlServer.Entities;
using ToDoList.Domain.SqlServer.Interfaces;

namespace ToDoList.AppService
{
    public class UserAppService : BaseService, IUserAppService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserAppService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultData> Post(CreateUserRequest request)
        {
            var user = new User(request.Email, request.Password);
            
            await _repository.Create(user);
            _unitOfWork.Commit();

            return SuccessData(EGenericOperations.Record_Saved_Successfully.GetDescription());
        }
    }
}
