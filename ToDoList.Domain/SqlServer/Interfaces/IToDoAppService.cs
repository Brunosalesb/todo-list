using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain.Contracts.Request;
using ToDoList.Domain.Entities;
using ToDoList.Domain.SqlServer.Contracts.Response;

namespace ToDoList.Domain.Interfaces
{
    public interface IToDoAppService
    {
        Task<ICollection<GetAllToDoResponse>> GetAll();
        Task<ToDo> GetById(int id);
        Task<ToDo> Post(CreateToDoRequest req);
        Task<ToDo> Update(UpdateToDoRequest req);
        Task DeleteById(int id);
    }
}
