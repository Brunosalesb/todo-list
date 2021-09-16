using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoList.Domain.SqlServer.Contracts.Request.User;
using ToDoList.Domain.SqlServer.Interfaces;

namespace ToDoList.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserAppService _appService;
        public UserController(IUserAppService appService)
        {
            _appService = appService;
        }

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
                return BadRequest(ex);
            }
        }
    }
}
