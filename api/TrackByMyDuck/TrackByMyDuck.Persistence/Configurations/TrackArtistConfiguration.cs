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
    internal class TrackArtistConfiguration: IEntityTypeConfiguration<TrackArtist>
    {
        public void Configure(EntityTypeBuilder<TrackArtist> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Track)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.NoAction)

            //    .HasForeignKey(x => x.TrackId);


            builder.HasOne(x => x.Artist)
                .WithMany()
                .HasForeignKey(x => x.ArtistId);

            
        }
    }
}
