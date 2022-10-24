using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Check(UserSpotifyTokenDto init)
        {
            Console.WriteLine(init);

            var spotify = new SpotifyClient(init.access_token);
            var data = await spotify.UserProfile.Current();


            return Ok(true);
        }
    }


    public class UserSpotifyTokenDto
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
    }
}
