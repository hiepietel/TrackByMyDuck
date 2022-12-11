using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Contracts.Persistence
{
    public interface ITrackRepository: IAsyncRepository<Track>
    {

    }
}
