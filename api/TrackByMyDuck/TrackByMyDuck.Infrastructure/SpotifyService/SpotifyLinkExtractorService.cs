using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Core.Interfaces;

namespace TrackByMyDuck.Application.Services
{
    public class SpotifyLinkExtractorService : ISpotifyLinkExtractorService
    {
        public Task<string> IsValidSpotifyTackLink(string spotifyTrackLink)
        {
            throw new NotImplementedException();
        }
    }
}
