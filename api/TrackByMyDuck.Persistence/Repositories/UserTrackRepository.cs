using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Persistence.Repositories
{
    public class UserTrackRepository : BaseRepository<UserTrack>, IUserTrackRepository
    {
        public UserTrackRepository(TrackByMyDuckContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<UserTrack>> ListAllWithAdditionalData()
        {
            return await _dbContext.UserTracks
                .Include(x => x.Track)
                .Include(x => x.Track.Album)
                .Include(x => x.Track.TrackArtists)
                       .ThenInclude(x => x.Artist)
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
