namespace ToDoList.Domain.SqlServer.Contracts.Request
{
    public class CreateToDoRequest
    {
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
