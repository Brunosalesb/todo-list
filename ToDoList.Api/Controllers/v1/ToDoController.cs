using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoList.Domain.Contracts.Request;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoAppService _appService;
        public ToDoController(IToDoAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _appService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var result = await _appService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateToDoRequest request)
        {
            try
            {
                await _appService.Post(request);
                return Ok(new { message = "ToDo successfully created" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateToDoRequest request)
        {
            try
            {
                await _appService.Update(request);
                return Ok(new { message = "ToDo successfully updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            try
            {
                await _appService.DeleteById(id);
                return Ok(new { message = "ToDo successfully deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
