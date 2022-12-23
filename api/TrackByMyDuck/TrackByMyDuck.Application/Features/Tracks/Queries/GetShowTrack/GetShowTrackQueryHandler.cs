﻿using AutoMapper;
using MediatR;
using TrackByMyDuck.Application.Contracts.Persistence;

namespace TrackByMyDuck.Application.Features.Tracks.Queries.GetShowTrack
{
    public class GetShowTrackQueryHandler : IRequestHandler<GetShowTrackQuery, ShowTrackVm>
    {

        public ITrackRepository _trackRepository;
        public IMapper _mapper;
        public GetShowTrackQueryHandler(IMapper mapper, ITrackRepository trackRepository)
        {
            _mapper = mapper;
            _trackRepository = trackRepository;
        }

        public async Task<ShowTrackVm> Handle(GetShowTrackQuery request, CancellationToken cancellationToken)
        {
            var showTrack = await _trackRepository.GetShowTrack();
            return new ShowTrackVm()
            {
                SpotifyId = showTrack.SpotifyId
            };
        }
    }
}