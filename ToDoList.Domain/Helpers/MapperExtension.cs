using System.Collections.Generic;
using ToDoList.Domain.SqlServer.Contracts.Response;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Domain.Helpers
{
    public static class MapperExtension
    {
        public static List<GetAllToDoResponse> MapGetAllToDoResponse(ICollection<ToDo> response)
        {
            var result = new List<GetAllToDoResponse>();

            foreach (var item in response)
                result.Add(MapperExtension.MapGetAllToDoResponse(item));

            return result;
        }

        public static GetAllToDoResponse MapGetAllToDoResponse(ToDo response)
        {
            return new GetAllToDoResponse()
            {
                Id = response.Id,
                Description = response.Description,
                Done = response.Done
            };
        }
    }
}