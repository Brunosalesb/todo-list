using System.Threading.Tasks;
using ToDoList.Domain.Shared;
using ToDoList.Domain.SqlServer.Contracts.Request;

namespace ToDoList.Domain.SqlServer.Interfaces
{
    public interface IToDoAppService
    {
        Task<ResultData> GetAll();
        Task<ResultData> GetById(int id);
        Task<ResultData> Post(CreateToDoRequest req);
        Task<ResultData> Update(UpdateToDoRequest req);
        Task<ResultData> DeleteById(int id);
    }
}
