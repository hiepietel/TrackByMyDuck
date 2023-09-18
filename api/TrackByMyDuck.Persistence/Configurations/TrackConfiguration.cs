using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Persistence.Configurations
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.SpotifyId).IsUnique();

            builder.HasOne(x => x.Album)
                .WithMany()
                .HasForeignKey(x => x.AlbumId);

            builder.HasMany(x => x.TrackArtists)
                .WithOne()
                .HasForeignKey(x => x.TrackId);
                            
        }
    }
}
