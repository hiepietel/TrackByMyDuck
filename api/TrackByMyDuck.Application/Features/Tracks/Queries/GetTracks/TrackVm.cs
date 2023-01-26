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
        public string SpotifyTrackId { get; set; }
        public string TrackName { get; set; } = string.Empty;
        public string ImgHref { get; set; } = string.Empty;
        public List<string> Artists { get; set; } = new List<string>();
        public string PreviewUrl { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserUrl { get; set; }
    }
}
