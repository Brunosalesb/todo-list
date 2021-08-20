using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain.SqlServer.Contracts.Request;
using ToDoList.Domain.SqlServer.Contracts.Response;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Domain.SqlServer.Interfaces
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
