using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Domain.SqlServer.Interfaces
{
    public interface IToDoRepository
    {
        Task Create(ToDo toDo);
        Task Update(ToDo toDo);
        Task Delete(ToDo toDo);
        Task<ToDo> GetById(int id);
        Task<ToDo> GetByIdAsNoTracking(int id);
        Task<ICollection<ToDo>> GetAll();
    }
}
