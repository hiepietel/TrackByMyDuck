using SpotifyAPI.Web;
using TrackByMyDuck.Core.SpotifyEntities;

namespace TrackByMyDuck.Core.Interfaces
{
    public interface ISpotifyService
    {
        Task<FullTrack> CheckTrackFromSpotifyId(string spotifyId);

        Task<List<SpotifyTrack>> GetTracksFromPlaylist(string spotifyUserToken, string spotifyPlaylistId);
    }
}