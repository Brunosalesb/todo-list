using System;
using ToDoList.Domain.Commands.Requests;

namespace ToDoList.Domain.Entities
{
    public class ToDo
    {
        public ToDo(string description)
        {
            Description = description;
            CreateDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? LastUpdateDate { get; private set; }
        public bool Done { get; private set; } = false;

        public void Atualizar(UpdateToDoRequest req)
        {
            Description = req.Description;
            Done = req.Done;
            LastUpdateDate = DateTime.Now;
        }
    }
}
