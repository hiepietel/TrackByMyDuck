﻿using System;
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
        public string ImgHref { get; set; } = string.Empty;
        public List<string> Artists { get; set; } = new List<string>();
        public string PreviewUrl { get; set; }
    }
}
