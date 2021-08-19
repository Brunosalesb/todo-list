using System;
using ToDoList.Domain.Contracts.Request;

namespace ToDoList.Domain.Entities
{
    public class ToDo
    {
        public ToDo()
        {
            // ef needs this constructor even though it is never called by 
            // my code in the application. EF needs it to set up the contexts

            // Failure to have it will result in a 
            //  No suitable constructor found for entity type 'Company'. exception
        }
        public ToDo(CreateToDoRequest request)
        {
            Description = request.Description;
            Done = request.Done;
            CreateDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? LastUpdateDate { get; private set; }
        public bool Done { get; private set; } = false;

        public void Update(UpdateToDoRequest request)
        {
            Description = request.Description;
            Done = request.Done;
            LastUpdateDate = DateTime.Now;
        }
    }
}
