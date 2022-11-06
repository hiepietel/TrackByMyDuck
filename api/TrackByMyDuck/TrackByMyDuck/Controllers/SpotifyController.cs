using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SpotifyController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public async Task<IActionResult> GetMainPlaylist()
        {
            var spotifyAccessToken = _configuration.GetSection("AppSettings:SpotifyToken").Value;
            var spotify = new SpotifyClient(spotifyAccessToken);
            //"https://open.spotify.com/playlist/3N7JOHotDn6MCp7nESgjf7?si=5247dfbd53914baf"
            //https://open.spotify.com/playlist/2plFn6cpqGu9e9JloPTTzp?si=7b302e87d57949c7
            string spotifyPlaylistId = _configuration.GetSection("AppSettings:SpotifyPlaylist").Value;
            var playlist = await spotify.Playlists.GetItems(spotifyPlaylistId);
            return Ok(playlist.Items);
        }
        [HttpPost]
        public async Task<IActionResult> AddTrack([FromBody] string values)
        {
            //https://open.spotify.com/album/4utVyX1HOqeMkUeeHijTUT?si=J0oxH7bGRlOkGMCjx0SuTA
            //https://open.spotify.com/track/1301WleyT98MSxVHPZCA6M?si=ef668b83df3e480f
            //1301WleyT98MSxVHPZCA6M
            //https://open.spotify.com/track/47rKwYHKChKwrw7503T2Bp?si=255a215795b74097
            //"spotify:track:47rKwYHKChKwrw7503T2Bp"

            var spotifyAccessToken = _configuration.GetSection("AppSettings:SpotifyToken").Value;
            var PlayListSporti = new PlaylistAddItemsRequest(new List<string>() { values });
            var spotify = new SpotifyClient(spotifyAccessToken);
            string spotifyPlaylistId = _configuration.GetSection("AppSettings:SpotifyPlaylist").Value;
            var addded = await spotify.Playlists.Get(spotifyPlaylistId);
            var addded1 = await spotify.Playlists.AddItems(spotifyPlaylistId, PlayListSporti);
            return Ok(true);
        }
    }
}