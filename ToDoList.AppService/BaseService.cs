using ToDoList.Domain.Shared;

namespace ToDoList.AppService
{
    public class BaseService
    {
        public static ResultData ErrorData(string errorMessage)
        {
            return new ResultData()
            {
                Data = errorMessage,
                Success = false
            };
        }
    }
}
