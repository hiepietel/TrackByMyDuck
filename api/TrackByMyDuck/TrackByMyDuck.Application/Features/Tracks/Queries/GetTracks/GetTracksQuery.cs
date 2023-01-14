using MediatR;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetShowTrack;

namespace TrackByMyDuck.Application.Features.Tracks.Queries.GetTracks
{
    public class GetTracksQuery: IRequest<List<TrackVm>>
    {
    }
}