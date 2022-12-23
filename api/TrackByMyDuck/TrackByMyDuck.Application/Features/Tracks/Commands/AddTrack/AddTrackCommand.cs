using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Application.Features.Tracks.Commands.AddTrack
{
    public class AddTrackCommand :IRequest<bool>
    {
        public string Link { get; set; }
    }
}
