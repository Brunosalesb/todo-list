using ToDoList.Domain.Shared.Interfaces;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Domain.SqlServer.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
