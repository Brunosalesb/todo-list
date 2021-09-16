using ToDoList.Domain.Shared.Interfaces;
using ToDoList.Domain.SqlServer.Contracts.Request.User;
using ToDoList.Domain.SqlServer.Contracts.Response.User;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Domain.SqlServer.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        GetUserAuthResponse GetByEmailAndPassword(CreateUserRequest request);
    }
}
