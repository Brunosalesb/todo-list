namespace ToDoList.Domain.SqlServer.Contracts.Request
{
    public class UpdateToDoRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
