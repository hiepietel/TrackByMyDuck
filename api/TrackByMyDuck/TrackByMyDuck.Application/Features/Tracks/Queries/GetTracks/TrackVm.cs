using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Application.Features.Tracks.Queries.GetTracks
{
    public class TrackVm
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
