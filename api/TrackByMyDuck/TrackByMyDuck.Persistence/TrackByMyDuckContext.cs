using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Persistence
{
    public class TrackByMyDuckContext: DbContext
    {
        public TrackByMyDuckContext(DbContextOptions<TrackByMyDuckContext> options) : base(options)
        {

        }
        public DbSet<Track> Tracks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //   //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrackByMyDuckContext).Assembly);
        //}
    }
} 