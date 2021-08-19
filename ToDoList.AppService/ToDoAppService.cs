using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain.Contracts.Request;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Helpers;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.SqlServer.Contracts.Response;

namespace ToDoList.AppService
{
    public class ToDoAppService : IToDoAppService
    {
        private readonly IToDoRepository _repository;

        public ToDoAppService(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteById(int id)
        {
            var toDo = await _repository.GetById(id);
            if (toDo == null)
                return;

            await _repository.Delete(toDo);
        }

        public async Task<ICollection<GetAllToDoResponse>> GetAll()
        {
            var toDoList = await _repository.GetAll();
            return MapperExtension.MapGetAllToDoResponse(toDoList);
        }

        public async Task<ToDo> GetById(int id)
        {
            var toDo = await _repository.GetByIdAsNoTracking(id);
            return toDo;
        }

        public async Task<ToDo> Post(CreateToDoRequest request)
        {
            var toDo = new ToDo(request);
            await _repository.Create(toDo);
            return toDo;
        }

        public async Task<ToDo> Update(UpdateToDoRequest request)
        {
            var toDo = await _repository.GetById(request.Id);

            if (toDo == null)
                return null;

            toDo.Update(request);
            await _repository.Update(toDo);
            return toDo;
        }
    }
}
