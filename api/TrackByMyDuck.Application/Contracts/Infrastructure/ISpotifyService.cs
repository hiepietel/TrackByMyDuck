using TrackByMyDuck.Application.Models.Spotify;

namespace TrackByMyDuck.Core.Interfaces
{
    public interface ISpotifyService
    {
        Task<SpotifyTrack> CheckTrackFromSpotifyId(string spotifyTrackId);

        //Task<List<SpotifyTrack>> GetTracksFromPlaylist(string spotifyUserToken, string spotifyPlaylistId);
        Task<SpotifyTrack> CheckAndCreateTrack(string spotifyTrackId);
    }
}