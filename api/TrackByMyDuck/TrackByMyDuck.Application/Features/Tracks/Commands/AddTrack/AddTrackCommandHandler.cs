using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Core.Interfaces;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Features.Tracks.Commands.AddTrack
{
    public class AddTrackCommandHandler : IRequestHandler<AddTrackCommand, bool>
    {
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;
        private readonly IMapper _mapper;
        private readonly ISpotifyLinkExtractorService _spotifyLinkExtractorService;
        private readonly ITrackRepository _trackRepository;

        public AddTrackCommandHandler(IConfiguration configuration, ISpotifyService spotifyService, IMapper mapper, ISpotifyLinkExtractorService spotifyLinkExtractorService, ITrackRepository trackRepository)
        {
            _configuration = configuration;
            _spotifyService = spotifyService;
            _mapper = mapper;
            _spotifyLinkExtractorService = spotifyLinkExtractorService;
            _trackRepository = trackRepository;
        }
        public async Task<bool> Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {

            var spotifyTrackId = await _spotifyLinkExtractorService.GetSpotifyIdFromLink(request.Link);
            var track = await _spotifyService.CheckAndCreateTrack(spotifyTrackId);

            var showTrack = await _trackRepository.AddAsync(_mapper.Map<Track>(track));

            return true;
        }
    }
}