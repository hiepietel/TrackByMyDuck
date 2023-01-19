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
    public class TrackRepository : BaseRepository<Track>, ITrackRepository
    {
        public TrackRepository(TrackByMyDuckContext dbContext) : base(dbContext)
        {
        }

        public async Task<Track> GetShowTrack()
        {
            var track = await _dbContext.Tracks.
                OrderBy(x => x.Id)
                .Take(1)
                .FirstOrDefaultAsync();

            return track;
        }

        public async Task<Track> GetBySpotifyIdAsync(string spotifyTrackId)
        {
            return await _dbContext.Tracks.FirstOrDefaultAsync(x => x.SpotifyId == spotifyTrackId);
        }

        public async Task<List<Track>> ListAllWithAdditionalData()
        {
            return await _dbContext.Tracks
                .Include(x => x.Album)
                .Include(x => x.TrackArtists)
                    .ThenInclude(x => x.Artist)
                .ToListAsync();
        }
    }
}
