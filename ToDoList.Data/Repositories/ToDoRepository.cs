using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public void Create(ToDo toDo)
        {
            _context.ToDo.Add(toDo);
            _context.SaveChanges();
        }

        public void Delete(ToDo toDo)
        {
            _context.ToDo.Remove(toDo);
            _context.SaveChanges();
        }

        public ICollection<ToDo> GetAll()
        {
            return _context.ToDo.AsNoTracking().ToList();
        }

        public ToDo GetById(int id)
        {
            return _context.ToDo.FirstOrDefault(x => x.Id == id);
        }

        public ToDo GetByIdAsNoTracking(int id)
        {
            return _context.ToDo.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Update(ToDo toDo)
        {
            _context.Entry(toDo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
