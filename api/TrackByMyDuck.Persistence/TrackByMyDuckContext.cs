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
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TrackArtist> TrackArtists { get; set; }
        public DbSet<UserTrack> UserTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrackByMyDuckContext).Assembly);
        }
    }
} 