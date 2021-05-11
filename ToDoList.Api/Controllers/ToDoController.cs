using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;
using ToDoList.Infra.Contexts;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Route("toDo")]
    public class ToDoController : ControllerBase
    {
        private readonly DataContext _context;
        public ToDoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> PostTodoItem(ToDo req)
        {
            _context.ToDo.Add(req);
            await _context.SaveChangesAsync();
            return Ok(req);
        }
    }
}
