using Microsoft.Extensions.Configuration;
using SpotifyAPI.Web;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Application.Models.Spotify;
using TrackByMyDuck.Core.Interfaces;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Services
{

    public class SpotifyService : ISpotifyService
    {
        private readonly IConfiguration _configuration;
        private readonly ITrackRepository _trackRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ITrackArtistRepository _trackArtistRepository;
        private readonly ISpotifyApiService _spotifyApiService;

        public SpotifyService(ISpotifyApiService spotifyApiService, ITrackRepository trackRepository, IArtistRepository artistRepository, IAlbumRepository albumRepository, ITrackArtistRepository trackArtistRepository)
        {
            _spotifyApiService = spotifyApiService;
            _trackRepository = trackRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
            _trackArtistRepository = trackArtistRepository;
        }

        public async Task<SpotifyTrack> CheckAndCreateTrack(string spotifyTrackId)
        {
            var track = await _trackRepository.GetBySpotifyIdAsync(spotifyTrackId);
            if (track != null)
            {
                return new SpotifyTrack()
                {
                    Id = track.Id,
                    //AlbumUrl = track.Album.ImgHref,
                    Name = track.Name,
                };
            }



            var spotifyTrack = await _spotifyApiService.GetTrackBySpotyfiyId(spotifyTrackId);

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
                    ImgHref = spotifyAlbum.Images.FirstOrDefault()?.Url,
                    
                };
                album = await _albumRepository.AddAsync(newAlbum);
            }

            var artists = await _artistRepository.GetBySpotifyIdAsync(artistSpotifyIds);

            var missingArtistsId = artistSpotifyIds.Where(x => artists.Select(y => y.SpotifyId).Contains(x) == false).ToList();


            var artistsToAdd = new List<Artist>();
            missingArtistsId.ForEach(x =>
            {
                var spotifyArtist = spotifyTrack.Artists.FirstOrDefault(e => e.Id == x);
                artistsToAdd.Add(new Artist()
                {
                    Name = spotifyArtist.Name,
                    SpotifyId = spotifyArtist.Id,

                });
            });


            await _artistRepository.AddManyAsync(artistsToAdd);


            var newTrack = new Track()
            {
                Name = spotifyTrack.Name,
                SpotifyId = spotifyTrackId,
                AlbumId = album.Id,
                PreviewUrl = spotifyTrack.PreviewUrl

            };
            await _trackRepository.AddAsync(newTrack);

            var trackArtistListToAdd = new List<TrackArtist>();
            artistsToAdd.ForEach(x =>
            {
                trackArtistListToAdd.Add(new TrackArtist()
                {
                    TrackId = newTrack.Id,
                    ArtistId = x.Id,
                });
            });

            await _trackArtistRepository.AddManyAsync(trackArtistListToAdd);

            //newTrack.TrackArtistId =  

            return new SpotifyTrack()
            {
                Id= newTrack.Id,
                ImgHref = album.ImgHref,
                Artists = artistsToAdd.Select(x => x.Name).ToList(),
                Name = newTrack.Name,
                PreviewUrl = spotifyTrack.PreviewUrl
            };

        }

        public async Task<SpotifyTrack> CheckTrackFromSpotifyId(string spotifyTrackId)
        {

            var spotifyTrack = await _spotifyApiService.GetTrackBySpotyfiyId(spotifyTrackId);

            var artists = spotifyTrack.Artists.Select(c => c.Name).ToList();

            var albym = spotifyTrack.Album.Images.Skip(1).FirstOrDefault().Url;


            return new SpotifyTrack()
            {
                SpotifyId = spotifyTrackId,
                PreviewUrl = spotifyTrack.PreviewUrl,
                Name = spotifyTrack.Name,
                Artists = artists,
                ImgHref = albym
            };
        }

        //public async Task<List<SpotifyTrack>> GetTracksFromPlaylist(string spotifyUserToken, string spotifyPlaylistId)
        //{
        //    //var a = User.Claims.Where(x => x.Type == ClaimTypes.UserData).ToList();
        //    //var spotifyAccessToken = _configuration.GetSection("AppSettings:SpotifyToken").Value;
        //    var spotify = new SpotifyClient(spotifyUserToken);
        //    //"https://open.spotify.com/playlist/3N7JOHotDn6MCp7nESgjf7?si=5247dfbd53914baf"
        //    //https://open.spotify.com/playlist/2plFn6cpqGu9e9JloPTTzp?si=7b302e87d57949c7
        //    //string spotifyPlaylistId = _configuration.GetSection("AppSettings:SpotifyPlaylist").Value;
        //    var tracks = new List<SpotifyTrack>();
        //    var playlist = await spotify.Playlists.GetItems(spotifyPlaylistId);

        //    if (playlist == null || playlist.Items == null)
        //    {
        //        return null;
        //    }
        //    foreach (var playlistItem in playlist?.Items)
        //    {
        //        var obj = (FullTrack)playlistItem.Track;
        //        tracks.Add(new SpotifyTrack()
        //        {
        //            //AddedBy = playlistItem.AddedBy.Id,
        //            //AddedDate = playlistItem.AddedAt.Value,
        //            //SpotifyId = obj.Id
        //        });
        //    }
        //    return tracks;
        //}
    }
}