using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Application.Features.Tracks.Commands.CheckTrack
{
    public class CheckTrackCommand: IRequest<string>
    {
        public string Link { get; set; }
    }
}
