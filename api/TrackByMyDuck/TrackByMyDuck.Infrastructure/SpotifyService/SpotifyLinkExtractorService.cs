using TrackByMyDuck.Core.Interfaces;
namespace TrackByMyDuck.Application.Services
{
    public class SpotifyLinkExtractorService : ISpotifyLinkExtractorService
    {
        public async Task<string> GetSpotifyIdFromLink(string spotifyTrackLink)
        {
            var res = spotifyTrackLink.Split("/")[4].Split("?")[0];

            return res;
        }
    }
}