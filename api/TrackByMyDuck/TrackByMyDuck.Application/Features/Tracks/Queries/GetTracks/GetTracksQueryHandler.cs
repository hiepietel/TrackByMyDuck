using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetShowTrack;

namespace TrackByMyDuck.Application.Features.Tracks.Queries.GetTracks
{
    public class GetTracksQueryHandler : IRequestHandler<GetTracksQuery, List<TrackVm>>
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;

        public GetTracksQueryHandler(IMapper mapper, ITrackRepository trackRepository)
        {
            _mapper = mapper;
            _trackRepository = trackRepository;
        }

        public async Task<List<TrackVm>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            var trackVmList = await _trackRepository.ListAllAsync();
            return _mapper.Map<List<TrackVm>>(trackVmList);
        }
    }
}
