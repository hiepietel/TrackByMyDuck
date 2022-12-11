using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI;
using SpotifyAPI.Web;
using TrackByMyDuck.Core.Interfaces;
using TrackByMyDuck.Core.SpotifyEntities;

namespace TrackByMyDuck.Application.Services
{
    public class SpotifyService: ISpotifyService
    {

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
                    AddedBy = playlistItem.AddedBy.Id,
                    AddedDate = playlistItem.AddedAt.Value,
                    SpotifyId = obj.Id
                });
            }
            return tracks;
        }
    }
}
