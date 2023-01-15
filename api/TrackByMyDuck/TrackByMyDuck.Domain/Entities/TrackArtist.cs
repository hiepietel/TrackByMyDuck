using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Domain.Entities
{
    public class TrackArtist
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int ArtistId { get; set; }

        public virtual Track Track { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
