using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Application.Contracts.Infrastructure
{
    public interface IUserTrackService
    {
        Task<bool> CreateFromTrack(int trackId);
    }
}
