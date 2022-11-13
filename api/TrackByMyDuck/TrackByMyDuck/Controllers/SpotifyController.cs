using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using System.Security.Claims;
using TrackByMyDuck.DTO;

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
        [Authorize]
        public async Task<IActionResult> GetMainPlaylist()
        {
            var a = User.Claims.Where(x => x.Type == ClaimTypes.UserData).ToList();
            var spotifyAccessToken = _configuration.GetSection("AppSettings:SpotifyToken").Value;
            var spotify = new SpotifyClient(a.FirstOrDefault().Value);
            //"https://open.spotify.com/playlist/3N7JOHotDn6MCp7nESgjf7?si=5247dfbd53914baf"
            //https://open.spotify.com/playlist/2plFn6cpqGu9e9JloPTTzp?si=7b302e87d57949c7
            string spotifyPlaylistId = _configuration.GetSection("AppSettings:SpotifyPlaylist").Value;
            var tracks = new List<SpotifyTrackDto>();
            var playlist = await spotify.Playlists.GetItems(spotifyPlaylistId);

            if (playlist == null || playlist.Items == null)
            {
                return NotFound(false);
            }
            foreach (var playlistItem in playlist?.Items)
            {
                var obj = (FullTrack)playlistItem.Track;
                tracks.Add(new SpotifyTrackDto()
                {
                    AddedBy = playlistItem.AddedBy.Id,
                    AddedDate = playlistItem.AddedAt.Value,
                    SpotifyId = obj.Id
                });
            }
            

            return Ok(tracks);
        }
        [HttpPost]
        [Authorize]
        
        public async Task<IActionResult> AddTrack([FromBody] string values)
        {
            //https://open.spotify.com/album/4utVyX1HOqeMkUeeHijTUT?si=J0oxH7bGRlOkGMCjx0SuTA
            //https://open.spotify.com/track/1301WleyT98MSxVHPZCA6M?si=ef668b83df3e480f
            //1301WleyT98MSxVHPZCA6M
            //https://open.spotify.com/track/47rKwYHKChKwrw7503T2Bp?si=255a215795b74097
            //"spotify:track:47rKwYHKChKwrw7503T2Bp"
            var ad = values.Split("\\")[2].Split("?")[0];
            var spotifyAccessToken = _configuration.GetSection("AppSettings:SpotifyToken").Value;
            var asd = Response.Cookies;
            var a = User.Claims;
                var PlayListSporti = new PlaylistAddItemsRequest(new List<string>() { values });
            var spotify = new SpotifyClient(spotifyAccessToken);
            string spotifyPlaylistId = _configuration.GetSection("AppSettings:SpotifyPlaylist").Value;
            var addded = await spotify.Playlists.Get(spotifyPlaylistId);
            var addded1 = await spotify.Playlists.AddItems(spotifyPlaylistId, PlayListSporti);
            return Ok(true);
        }
    }
}