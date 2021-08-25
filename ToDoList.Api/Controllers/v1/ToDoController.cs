using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoList.Domain.SqlServer.Contracts.Request;
using ToDoList.Domain.SqlServer.Interfaces;

namespace ToDoList.Api.Controllers
{
    [ApiController]
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
                var result = await _appService.Post(request);
                return Ok(result);
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
                var result = await _appService.Update(request);
                return Ok(result);
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
                var result = await _appService.DeleteById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
