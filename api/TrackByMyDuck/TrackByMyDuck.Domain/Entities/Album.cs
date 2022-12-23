using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Domain.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
    }
}
