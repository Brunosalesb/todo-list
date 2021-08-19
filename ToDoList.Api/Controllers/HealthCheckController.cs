using Microsoft.AspNetCore.Mvc;
using System;

namespace ToDoList.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Check()
        {
            string result = "OK";
            Console.WriteLine(result);
            return new ActionResult<string>(result);
        }
    }
}
