using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ToDoList.Domain.SqlServer.Contracts.Request.User;
using ToDoList.Domain.SqlServer.Entities;
using ToDoList.Domain.SqlServer.Interfaces;

namespace ToDoList.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserAppService _appService;
        private readonly ILogger<User> _logger;

        public UserController(IUserAppService appService, ILogger<User> logger)
        {
            _appService = appService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
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
    }
}
