using System.Collections.Generic;
using ToDoList.Domain.SqlServer.Contracts.Response;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Domain.Helpers
{
    public static class MapperExtension
    {
        public static List<GetAllToDoResponse> MapGetAllToDoResponse(this ICollection<ToDo> response)
        {
            var result = new List<GetAllToDoResponse>();

            foreach (var item in response)
                result.Add(item.MapGetAllToDoResponse());

            return result;
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

        public static GetByIdToDoResponse MapGetByIdToDoResponse(this ToDo response)
        {
            return new GetByIdToDoResponse()
            {
                Id = response.Id,
                Description = response.Description,
                CreateDate = response.CreateDate,
                Done = response.Done
            };
        }
    }
}