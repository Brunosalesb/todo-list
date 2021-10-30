using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ToDoList.Api.Services;
using ToDoList.Domain.SqlServer.Contracts.Request.User;
using ToDoList.Domain.SqlServer.Interfaces;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthController(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<dynamic> Authenticate([FromBody] CreateUserRequest request)
        {
            var user = _repository.GetByEmailAndPassword(request);

            if (user == null)
                return NotFound(new { message = "Invalid credentials" });

            var token = TokenService.GenerateToken(user.Id.ToString(), user.Email, _configuration);

            return new
            {
                token
            };
        }
    }
}
