using System.Threading.Tasks;
using ToDoList.Domain.Shared;
using ToDoList.Domain.SqlServer.Contracts.Request;

namespace ToDoList.Domain.SqlServer.Interfaces
{
    public interface IToDoAppService
    {
        Task<ResultData> GetAll();
        Task<ResultData> GetById(int id);
        Task Post(CreateToDoRequest req);
        Task Update(UpdateToDoRequest req);
        Task DeleteById(int id);
    }
}
