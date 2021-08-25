﻿using System.Threading.Tasks;
using ToDoList.Domain.Helpers;
using ToDoList.Domain.Shared;
using ToDoList.Domain.SqlServer.Contracts.Request;
using ToDoList.Domain.SqlServer.Entities;
using ToDoList.Domain.SqlServer.Interfaces;

namespace ToDoList.AppService
{
    public class ToDoAppService : BaseService, IToDoAppService
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

        public async Task<ResultData> GetAll()
        {
            var toDoList = await _repository.GetAll();
            if (toDoList == null)
                return ErrorData(EGenericErrors.No_Records_Found.GetDescription());

            return toDoList.MapGetAllToDoResponse();
        }

        public async Task<ResultData> GetById(int id)
        {
            var toDo = await _repository.GetByIdAsNoTracking(id);
            if (toDo == null)
                return ErrorData(EGenericErrors.No_Records_Found.GetDescription());

            return toDo.MapGetByIdToDoResponse();
        }

        public async Task Post(CreateToDoRequest request)
        {
            var toDo = new ToDo(request);
            await _repository.Create(toDo);
        }

        public async Task Update(UpdateToDoRequest request)
        {
            var toDo = await _repository.GetById(request.Id);

            if (toDo == null)
                return;

            toDo.Update(request);
            await _repository.Update(toDo);
        }
    }
}
