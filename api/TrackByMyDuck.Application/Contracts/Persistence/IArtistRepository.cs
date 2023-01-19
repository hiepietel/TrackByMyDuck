using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Contracts.Persistence
{
    public interface IArtistRepository: IAsyncRepository<Artist>
    {
        Task<List<Artist>> GetBySpotifyIdAsync(List<string> spotifyTrackId);
    }
}