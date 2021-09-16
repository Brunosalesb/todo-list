using System.Threading.Tasks;
using ToDoList.Domain.Shared;
using ToDoList.Domain.SqlServer.Contracts.Request.User;

namespace ToDoList.Domain.SqlServer.Interfaces
{
    public interface IUserAppService
    {
        Task<ResultData> Post(CreateUserRequest request);
    }
}
