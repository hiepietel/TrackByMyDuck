using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Application.Models.Spotify
{
    public class SpotifyTrack
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string AlbumUrl { get; set; }
        public List<string> Artists { get; set; }
        public string PreviewUrl { get; set; }
    }
}
