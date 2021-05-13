using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Domain.Commands.Requests;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Contexts;
using ToDoList.Infra.Repositories;

namespace ToDoList.AppService
{
    public class ToDoAppService : IToDoAppService
    {
        private readonly DataContext _context;
        private readonly IToDoRepository _repository;

        public ToDoAppService(DataContext context, IToDoRepository repository)
        {
            _context = context;
            _repository = repository;
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

        public ToDo Post(CreateToDoRequest req)
        {
            var toDo = new ToDo(req);
            _repository.Create(toDo);
            _context.SaveChanges();
            return toDo;
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
