using Microsoft.AspNetCore.Mvc;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyController: ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Get([FromBody]object init)
        {

            return Ok(true);
        }
    }
}
