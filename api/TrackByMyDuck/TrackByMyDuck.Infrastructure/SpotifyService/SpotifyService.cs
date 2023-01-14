using Microsoft.Extensions.Configuration;
using SpotifyAPI.Web;
using System.Security.Cryptography.X509Certificates;
using TrackByMyDuck.Application.Models.Spotify;
using TrackByMyDuck.Core.Interfaces;

namespace TrackByMyDuck.Application.Services
{
    public class SpotifyService: ISpotifyService
    {
        private readonly IConfiguration _configuration;
        public SpotifyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SpotifyTrack> CheckTrackFromSpotifyId(string spotifyId)
        {

            var config = SpotifyClientConfig.CreateDefault();
            var clientId = _configuration.GetSection("Spotify:ClientId")?.Value;
            var clientSecret = _configuration.GetSection("Spotify:ClientSecret")?.Value;
            var request = new ClientCredentialsRequest(clientId, clientSecret);
            var response = await new OAuthClient(config).RequestToken(request);

            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

            var track = await spotify.Tracks.Get(spotifyId);

            var artists = track.Artists.Select(c => new { c.Id, c.Name }).ToList();
            
            var albym = track.Album.Images.Skip(1).FirstOrDefault().Url;

            
            return new SpotifyTrack()
            {
                SpotifyId = spotifyId,
                Name = track.Name,
                AlbumUrl = albym,
            };
        }

        public async Task<List<SpotifyTrack>> GetTracksFromPlaylist(string spotifyUserToken, string spotifyPlaylistId)
        {
            //var a = User.Claims.Where(x => x.Type == ClaimTypes.UserData).ToList();
            //var spotifyAccessToken = _configuration.GetSection("AppSettings:SpotifyToken").Value;
            var spotify = new SpotifyClient(spotifyUserToken);
            //"https://open.spotify.com/playlist/3N7JOHotDn6MCp7nESgjf7?si=5247dfbd53914baf"
            //https://open.spotify.com/playlist/2plFn6cpqGu9e9JloPTTzp?si=7b302e87d57949c7
            //string spotifyPlaylistId = _configuration.GetSection("AppSettings:SpotifyPlaylist").Value;
            var tracks = new List<SpotifyTrack>();
            var playlist = await spotify.Playlists.GetItems(spotifyPlaylistId);

            if (playlist == null || playlist.Items == null)
            {
                return null;
            }
            foreach (var playlistItem in playlist?.Items)
            {
                var obj = (FullTrack)playlistItem.Track;
                tracks.Add(new SpotifyTrack()
                {
                    //AddedBy = playlistItem.AddedBy.Id,
                    //AddedDate = playlistItem.AddedAt.Value,
                    //SpotifyId = obj.Id
                });
            }
            return tracks;
        }
    }
}