using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Core.Interfaces
{
    public interface ISpotifyLinkExtractorService
    {
        Task<string> IsValidSpotifyTackLink(string spotifyTrackLink);
    }
}
