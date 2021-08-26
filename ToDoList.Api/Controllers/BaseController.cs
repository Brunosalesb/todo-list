using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Helpers;
using ToDoList.Domain.Shared;
using ToDoList.Domain.Shared.Enums;

namespace ToDoList.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        //without nonAction swagger return error Failed to load API definition.
        [NonAction]
        public new IActionResult Response(ResultData result)
        {
            if (result.Success)
                return Ok(result);
            else
                return DefineErrorCode(result);
        }

        private IActionResult DefineErrorCode(ResultData result)
        {
            if (result.Data.ToString() == EGenericErrors.No_Records_Found.GetDescription())
                return NotFound(result);
            else
                return BadRequest(result);
        }
    }
}
