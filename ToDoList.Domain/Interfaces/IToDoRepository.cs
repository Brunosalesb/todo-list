using System.Collections.Generic;
using ToDoList.Domain.Commands.Requests;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces
{
    public interface IToDoRepository
    {
        void Create(ToDo toDo);
        void Update(ToDo toDo);
        void Delete(ToDo toDo);
        ToDo GetById(int id);
        ToDo GetByIdAsNoTracking(int id);
        ICollection<ToDo> GetAll();
    }
}
