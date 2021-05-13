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
        private readonly IToDoRepository _repository;

        public ToDoAppService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public void DeleteById(int id)
        {
            var toDo = _repository.GetById(id);
            if (toDo == null)
                return;

            _repository.Delete(toDo);
        }

        public ICollection<ToDo> GetAll()
        {
            var toDoList = _repository.GetAll();
            return toDoList;
        }

        public ToDo GetById(int id)
        {
            var toDo = _repository.GetByIdAsNoTracking(id);
            return toDo;
        }

        public ToDo Post(CreateToDoRequest req)
        {
            var toDo = new ToDo(req);
            _repository.Create(toDo);
            return toDo;
        }

        public ToDo Update(UpdateToDoRequest req)
        {
            var toDo = _repository.GetById(req.Id);

            if (toDo == null)
                return null;

            toDo.Update(req);
            _repository.Update(toDo);
            return toDo;
        }
    }
}
