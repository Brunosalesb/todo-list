using ToDoList.Domain.Commands.Requests;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces
{
    public interface IToDoRepository
    {
        void Create(ToDo request);
    }
}
