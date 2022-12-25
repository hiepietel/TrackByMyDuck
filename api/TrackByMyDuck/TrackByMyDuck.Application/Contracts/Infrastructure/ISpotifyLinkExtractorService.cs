namespace TrackByMyDuck.Core.Interfaces
{
    public interface ISpotifyLinkExtractorService
    {
        Task<string> GetSpotifyIdFromLink(string spotifyTrackLink);
    }
}