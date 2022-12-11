using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Persistence
{
    public class TruckByMyDuckContext: DbContext
    {
        public TruckByMyDuckContext(DbContextOptions<TruckByMyDuckContext> options) : base(options)
        {

        }
        public DbSet<Track> Tracks { get; set; }
    }
}