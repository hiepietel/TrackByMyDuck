using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Persistence.Configurations
{
    public class UserTrackConfiguration : IEntityTypeConfiguration<UserTrack>
    {
        public void Configure(EntityTypeBuilder<UserTrack> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Track)
                .WithMany()
                .HasForeignKey(x => x.TrackId);            
            
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
