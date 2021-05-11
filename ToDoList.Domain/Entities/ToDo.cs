using System;

namespace ToDoList.Domain.Entities
{
    public class ToDo
    {
        public ToDo(string description)
        {
            Description = description;
            CreateDate = DateTime.Now;
            Done = false;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool Done { get; private set; }
    }
}
