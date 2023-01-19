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
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(TrackByMyDuckContext dbContext) : base(dbContext)
        {
        }

        public async Task<Album> GetBySpotifyIdAsync(string spotifyId)
        {
            return await _dbContext.Albums.FirstOrDefaultAsync(x => x.SpotifyId == spotifyId);
        }
    }
}
