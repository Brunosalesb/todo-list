namespace ToDoList.Domain.Commands.Requests
{
    public class CreateToDoRequest
    {
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
