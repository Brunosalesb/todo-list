namespace ToDoList.Domain.SqlServer.Contracts.Request.User
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
