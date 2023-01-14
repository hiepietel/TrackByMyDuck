using Microsoft.Extensions.Configuration;
using SpotifyAPI.Web;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Application.Models.Spotify;
using TrackByMyDuck.Core.Interfaces;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Services
{
    public class SpotifyService: ISpotifyService
    {
        private readonly IConfiguration _configuration;
        private readonly ITrackRepository _trackRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;
        public SpotifyService(IConfiguration configuration, ITrackRepository trackRepository, IArtistRepository artistRepository, IAlbumRepository albumRepository)
        {
            _configuration = configuration;
            _trackRepository = trackRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
        }

        public async Task<SpotifyTrack> CheckAndCreateTrack(string spotifyTrackId)
        {
            var track = await _trackRepository.GetBySpotifyIdAsync(spotifyTrackId);
            if (track == null)
            {
                var config = SpotifyClientConfig.CreateDefault();
                var clientId = _configuration.GetSection("Spotify:ClientId")?.Value;
                var clientSecret = _configuration.GetSection("Spotify:ClientSecret")?.Value;
                var request = new ClientCredentialsRequest(clientId, clientSecret);
                var response = await new OAuthClient(config).RequestToken(request);

                var spotify = new SpotifyClient(config.WithToken(response.AccessToken));

                var spotifyTrack = await spotify.Tracks.Get(spotifyTrackId);

                var artistSpotifyIds = spotifyTrack.Artists.Select(x => x.Id).ToList();
                var spotifyAlbum = spotifyTrack.Album;

                var album = await _albumRepository.GetBySpotifyIdAsync(spotifyAlbum.Id);
                if (album == null)
                {
                    var newAlbum = new Album()
                    {
                        Name = spotifyAlbum.Name,
                        TotalTracks = spotifyAlbum.TotalTracks,
                        SpotifyId = spotifyAlbum.Id,
                        ImgHref = spotifyAlbum.Images.FirstOrDefault()?.Url
                    };
                    album = await _albumRepository.AddAsync(newAlbum);
                }

                var artists = await _artistRepository.GetBySpotifyIdAsync(artistSpotifyIds);

                var newTrack = new Track()
                {
                    Name = spotifyTrack.Name,
                    SpotifyId = spotifyTrackId,
                    AlbumId = album.Id,
                    
                };
                await _trackRepository.AddAsync(newTrack);

            }
            else
            {
                return new SpotifyTrack();
            }
            return new SpotifyTrack();
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