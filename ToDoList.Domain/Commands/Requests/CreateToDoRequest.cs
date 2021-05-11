using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Commands.Requests
{
    public class CreateToDoRequest
    {
        public string Description { get; set; }
    }
}
