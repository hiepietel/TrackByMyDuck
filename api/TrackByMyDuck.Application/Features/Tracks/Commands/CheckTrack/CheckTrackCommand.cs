using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Models.Spotify;

namespace TrackByMyDuck.Application.Features.Tracks.Commands.CheckTrack
{
    public class CheckTrackCommand: IRequest<CheckTrackVm>
    {
        public string Link { get; set; }
    }
}
