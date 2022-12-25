using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using System.Security.Claims;
using TrackByMyDuck.Core.Interfaces;
using TrackByMyDuck.Dtos;
using TrackByMyDuck.Queries.Spotify;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;
        private readonly IMapper _mapper;
        public SpotifyController(IConfiguration configuration, ISpotifyService spotifyService, IMapper mapper)
        {
            _configuration = configuration;
            _spotifyService = spotifyService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route("v2")]
        public async Task<IActionResult> GetMainPlaylist1()
        {
            var a = User.Claims.Where(x => x.Type == ClaimTypes.UserData).ToList();
            string spotifyPlaylistId = _configuration.GetSection("AppSettings:SpotifyPlaylist").Value;

            var response = await _spotifyService.GetTracksFromPlaylist(a.FirstOrDefault().Value, spotifyPlaylistId);
            
            return Ok(_mapper.Map<SpotifyTrackDto>(response));
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
            return Ok(tracks.OrderBy(x => x.AddedDate).Reverse());
        }


        [HttpPost]
        public async Task<IActionResult> AddTrack([FromBody] AddTrackQuery query)
        {
            //https://open.spotify.com/album/4utVyX1HOqeMkUeeHijTUT?si=J0oxH7bGRlOkGMCjx0SuTA
            //https://open.spotify.com/track/1301WleyT98MSxVHPZCA6M?si=ef668b83df3e480f
            //1301WleyT98MSxVHPZCA6M
            //https://open.spotify.com/track/47rKwYHKChKwrw7503T2Bp?si=255a215795b74097
            //"spotify:track:47rKwYHKChKwrw7503T2Bp"
            var ad = query.Link.Split("/")[4].Split("?")[0];
               // 
            //var spotifyAccessToken = _configuration.GetSection("AppSettings:SpotifyToken").Value;
            //var asd = Response.Cookies;
            var a = User.Claims.Where(x => x.Type == ClaimTypes.UserData).ToList();
            var PlayListSporti = new PlaylistAddItemsRequest(new List<string>() { "spotify:track:"+ ad });
            var spotify = new SpotifyClient(a.FirstOrDefault().Value);
            string spotifyPlaylistId = _configuration.GetSection("AppSettings:SpotifyPlaylist").Value;
            var addded1 = await spotify.Playlists.AddItems(spotifyPlaylistId, PlayListSporti);
            return Ok(ad);
        }
    }
}