using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class PingController : ControllerBase
    {
        [HttpGet(Name = "SimplePing")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<ActionResult<object>> SimplePing()
        {
            var result = new
            {
                Message = "Hello, world",
                Now = DateTime.Now,

            };
            return Ok(result);
        }

        [HttpGet("/db", Name = "EntityFrameworkPing")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<ActionResult<object>> EntityFrameworkPing()
        {
            var result = new
            {
                Message = "Hello, world db",
                Now = DateTime.Now,

            };
            return Ok(result);
        }

    }
}
