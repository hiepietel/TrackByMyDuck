using Microsoft.EntityFrameworkCore;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Persistence.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(TrackByMyDuckContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Artist>> GetBySpotifyIdAsync(List<string> spotifyTrackId)
        {
            return await _dbContext.Artists.Where(x => spotifyTrackId.Contains(x.SpotifyId)).ToListAsync();
        }
    }
}
