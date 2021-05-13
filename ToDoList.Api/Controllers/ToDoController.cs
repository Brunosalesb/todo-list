using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ToDoList.Domain.Commands.Requests;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Route("toDo/")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoAppService _appService;
        public ToDoController(IToDoAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public ActionResult<List<ToDo>> GetAll()
        {
            try
            {
                var toDoList = _appService.GetAll();
                return Ok(toDoList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<List<ToDo>> GetById([FromRoute] int id)
        {
            try
            {
                var toDo = _appService.GetById(id);
                return Ok(toDo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<ToDo> Post([FromBody] CreateToDoRequest req)
        {
            try
            {
                var toDo = _appService.Post(req);
                return Ok(toDo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public ActionResult<ToDo> Update([FromBody] UpdateToDoRequest req)
        {
            try
            {
                var toDo = _appService.Update(req);
                return Ok(toDo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> DeleteById([FromRoute] int id)
        {
            try
            {
                _appService.DeleteById(id);
                return Ok(new { message = "To do successfully deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
