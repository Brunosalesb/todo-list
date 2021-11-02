using System.Threading.Tasks;
using ToDoList.Domain.Helpers;
using ToDoList.Domain.Shared;
using ToDoList.Domain.Shared.Enums;
using ToDoList.Domain.Shared.Transactions;
using ToDoList.Domain.SqlServer.Contracts.Request;
using ToDoList.Domain.SqlServer.Entities;
using ToDoList.Domain.SqlServer.Interfaces;

namespace ToDoList.AppService
{
    public class ToDoAppService : BaseService, IToDoAppService
    {
        private readonly IToDoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ToDoAppService(IToDoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultData> DeleteById(int id)
        {
            var toDo = await _repository.GetById(id);
            if (toDo == null)
                return ErrorData(EGenericErrors.No_Records_Found.GetDescription());

            await _repository.Delete(toDo);
            _unitOfWork.Commit();

            return SuccessData(EGenericOperations.Record_Deleted_Successfully.GetDescription());
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

        public async Task<ResultData> Post(CreateToDoRequest request)
        {
            var toDo = new ToDo(request);

            await _repository.Create(toDo);
            _unitOfWork.Commit();

            return SuccessData(EGenericOperations.Record_Saved_Successfully.GetDescription());
        }

        public async Task<ResultData> Update(UpdateToDoRequest request)
        {
            var toDo = await _repository.GetById(request.Id);

            if (toDo == null)
                return ErrorData(EGenericErrors.No_Records_Found.GetDescription());

            toDo.Update(request);

            await _repository.Update(toDo);
            _unitOfWork.Commit();

            return SuccessData(EGenericOperations.Record_Updated_Successfully.GetDescription());
        }
    }
}
