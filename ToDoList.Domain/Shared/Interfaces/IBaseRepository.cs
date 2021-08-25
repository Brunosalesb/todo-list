using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.Domain.Shared.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);
        Task<ICollection<T>> GetAll();
    }
}
