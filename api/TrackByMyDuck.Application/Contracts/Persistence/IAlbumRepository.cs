using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Contracts.Persistence
{
    public interface IAlbumRepository : IAsyncRepository<Album>
    {
        public Task<Album> GetBySpotifyIdAsync(string spotifyId);
    }
}