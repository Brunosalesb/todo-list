using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.Commands.Requests;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Contexts;

namespace ToDoList.AppService
{
    public class ToDoAppService : IToDoAppService
    {
        private readonly DataContext _context;

        public ToDoAppService(DataContext context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            var toDo = _context.ToDo.FirstOrDefault(x => x.Id == id);
            if (toDo == null)
                return;

            _context.ToDo.Remove(toDo);
            _context.SaveChanges();
        }

        public ICollection<ToDo> GetAll()
        {
            var toDoList = _context.ToDo.AsNoTracking().ToList();
            return toDoList;
        }

        public ToDo GetById(int id)
        {
            var toDo = _context.ToDo.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return toDo;
        }

        public ToDo Post(ToDo req)
        {
            _context.ToDo.Add(req);
            _context.SaveChanges();
            return req;
        }

        public ToDo Update(UpdateToDoRequest req)
        {
            var toDo = _context.ToDo.FirstOrDefault(x => x.Id == req.Id);

            if (toDo == null)
                return null;

            toDo.Atualizar(req);

            _context.Entry(toDo).State = EntityState.Modified;
            _context.SaveChanges();
            return toDo;
        }
    }
}
