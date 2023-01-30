using MediatR;

namespace TrackByMyDuck.Application.Features.Tracks.Commands.AddTrack
{
    public class AddTrackCommand: IRequest<AddTrackVm>
    {
        public string Link { get; set; }
    }
}