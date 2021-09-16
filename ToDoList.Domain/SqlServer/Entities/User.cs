using System;
using ToDoList.Domain.Helpers;

namespace ToDoList.Domain.SqlServer.Entities
{
    public class User
    {
        public User(string email, string password)
        {
            Email = email;
            Password = StringHelper.EncryptPassword(password);
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
