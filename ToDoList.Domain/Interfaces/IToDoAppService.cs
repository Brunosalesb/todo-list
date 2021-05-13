using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain.Commands.Requests;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces
{
    public interface IToDoAppService
    {
        ICollection<ToDo> GetAll();
        ToDo GetById(int id);
        ToDo Post(CreateToDoRequest req);
        ToDo Update(UpdateToDoRequest req);
        void DeleteById(int id);
    }
}
