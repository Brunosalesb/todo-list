using ToDoList.Domain.Commands.Requests;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Contexts;

namespace ToDoList.Infra.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext _context;
        public ToDoRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(ToDo request)
        {
            _context.ToDo.Add(request);
        }
    }
}
