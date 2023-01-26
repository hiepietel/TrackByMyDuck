using MediatR;

namespace TrackByMyDuck.Application.Features.Tracks.Commands.AddTrack
{
    public class AddTrackCommand: IRequest<bool>
    {
        public string Link { get; set; }
    }
}