using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Application.Contracts.Infrastructure
{
    public interface ISpotifyApiService
    {
        Task<FullTrack> GetTrackBySpotyfiyId(string spotifyTrackId);
    }
}
