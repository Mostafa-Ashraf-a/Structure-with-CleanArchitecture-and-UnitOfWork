using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;

namespace MostafaProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult BaseResponseHandler<T>(KeyValuePair<ResponseEnum, T> response)
        {
            switch (response.Key)
            {
                case ResponseEnum.OK:
                    return Ok(response.Value);
                case ResponseEnum.Validation:
                    return BadRequest(response.Value);
                case ResponseEnum.NotFound:
                    return NotFound(response.Value);
                case ResponseEnum.Unothorized:
                    return StatusCode(403, response.Value);
                default:
                    return StatusCode(500, response.Value);
            }
        }
    }
}
