using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Core.SpotifyEntities;

namespace TrackByMyDuck.Core.Interfaces
{
    public interface ISpotifyService
    {
        Task CheckSpotifyTrack(string spotifyId);

        Task<List<SpotifyTrack>> GetTracksFromPlaylist(string spotifyUserToken, string spotifyPlaylistId);
    }
}
