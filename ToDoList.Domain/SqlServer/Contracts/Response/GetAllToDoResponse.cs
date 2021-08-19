namespace ToDoList.Domain.SqlServer.Contracts.Response
{
    public class GetAllToDoResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
