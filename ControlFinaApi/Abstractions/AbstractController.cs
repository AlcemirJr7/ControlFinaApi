using ControlFinaApi.Features;
using Microsoft.AspNetCore.Mvc;

namespace ControlFinaApi.Abstractions
{
    [Produces("application/json")]
    public abstract class AbstractController : ControllerBase
    {
        protected IActionResult HandleResponse<T>(Result<T> result, string? uri = null)
        {
            switch(result.StatusCode)
            {
                case StatusCodes.Status200OK: return Ok(result);
                case StatusCodes.Status201Created: return Created(uri, result);
                case StatusCodes.Status400BadRequest: return BadRequest(result);
                case StatusCodes.Status404NotFound: return NotFound(result);
                default: return BadRequest(result);
            }
        }
    }
}
