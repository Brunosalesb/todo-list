using System.Threading.Tasks;
using ToDoList.Domain.Shared.Interfaces;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Domain.SqlServer.Interfaces
{
    public interface IToDoRepository : IBaseRepository<ToDo>
    {
        Task<ToDo> GetByIdAsNoTracking(int id);
    }
}
