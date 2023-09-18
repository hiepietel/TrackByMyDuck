using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class PingController : ControllerBase
    {
        [HttpGet(Name = "SimplePing")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<object>> SimplePing()
        {
            var result = new
            {
                Message = "Hello, world",
                Now = DateTime.Now,

            };
            return Ok(result);
        }
    }
}
