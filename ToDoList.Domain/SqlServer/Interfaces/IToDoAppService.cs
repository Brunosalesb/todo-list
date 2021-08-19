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
        Task<GetByIdToDoResponse> GetById(int id);
        Task Post(CreateToDoRequest req);
        Task Update(UpdateToDoRequest req);
        Task DeleteById(int id);
    }
}
