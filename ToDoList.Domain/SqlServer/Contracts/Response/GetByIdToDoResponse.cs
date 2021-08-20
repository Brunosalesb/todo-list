using System;

namespace ToDoList.Domain.SqlServer.Contracts.Response
{
    public class GetByIdToDoResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Done { get; set; }
    }
}
