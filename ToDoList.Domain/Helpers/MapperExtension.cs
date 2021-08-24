using System.Collections.Generic;
using ToDoList.Domain.Shared;
using ToDoList.Domain.SqlServer.Contracts.Response;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Domain.Helpers
{
    public static class MapperExtension
    {
        public static ResultData MapGetAllToDoResponse(this ICollection<ToDo> response)
        {
            var result = new List<GetAllToDoResponse>();

            foreach (var item in response)
                result.Add(item.MapGetAllToDoResponse());

            return new ResultData()
            {
                Data = result,
                Success = true
            };
        }

        private static GetAllToDoResponse MapGetAllToDoResponse(this ToDo response)
        {
            return new GetAllToDoResponse()
            {
                Id = response.Id,
                Description = response.Description,
                Done = response.Done
            };
        }

        public static ResultData MapGetByIdToDoResponse(this ToDo response)
        {
            var result = new GetByIdToDoResponse()
            {
                Id = response.Id,
                Description = response.Description,
                CreateDate = response.CreateDate,
                Done = response.Done
            };

            return new ResultData()
            {
                Data = result,
                Success = true
            };
        }
    }
}