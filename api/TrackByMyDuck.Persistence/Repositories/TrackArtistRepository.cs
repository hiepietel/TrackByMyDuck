using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Persistence.Repositories
{
    public class TrackArtistRepository : BaseRepository<TrackArtist>, ITrackArtistRepository
    {
        public TrackArtistRepository(TrackByMyDuckContext dbContext) : base(dbContext)
        {

        }
    }
}
