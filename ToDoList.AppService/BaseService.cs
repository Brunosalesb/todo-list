using ToDoList.Domain.Shared;

namespace ToDoList.AppService
{
    public class BaseService
    {
        public static ResultData ErrorData(string message)
        {
            return new ResultData()
            {
                Data = message,
                Success = false
            };
        }

        public static ResultData SuccessData(string message)
        {
            return new ResultData()
            {
                Data = message,
                Success = true
            };
        }
    }
}
