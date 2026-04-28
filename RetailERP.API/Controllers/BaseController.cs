using Application.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace RetailERP.API.Controllers
{
    [ApiController] 
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleResult<T> (Result<T> result)
        {
            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }


        protected IActionResult HandleResult(Result result)
        {
            if(result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
