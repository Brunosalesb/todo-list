using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ToDoList.Domain.SqlServer.Contracts.Request;
using ToDoList.Domain.SqlServer.Entities;
using ToDoList.Domain.SqlServer.Interfaces;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class ToDoController : BaseController
    {
        private readonly IToDoAppService _appService;
        private readonly ILogger<ToDo> _logger;

        public ToDoController(IToDoAppService appService, ILogger<ToDo> logger)
        {
            _appService = appService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _appService.GetAll();
                return Response(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: {message}", ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var result = await _appService.GetById(id);
                return Response(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: {message}", ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateToDoRequest request)
        {
            try
            {
                var result = await _appService.Post(request);
                return Response(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: {message}", ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateToDoRequest request)
        {
            try
            {
                var result = await _appService.Update(request);
                return Response(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: {message}", ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            try
            {
                var result = await _appService.DeleteById(id);
                return Response(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: {message}", ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
