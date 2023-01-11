using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Application.Models.Spotify;
using TrackByMyDuck.Core.Interfaces;

namespace TrackByMyDuck.Application.Features.Tracks.Commands.CheckTrack
{
    public class CheckTrackCommandHandler : IRequestHandler<CheckTrackCommand, SpotifyTrack>
    {
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;
        private readonly IMapper _mapper;
        private readonly ISpotifyLinkExtractorService _spotifyLinkExtractorService;
        private readonly ITrackRepository _trackRepository;
        public CheckTrackCommandHandler(IConfiguration configuration, ISpotifyService spotifyService, IMapper mapper, ISpotifyLinkExtractorService spotifyLinkExtractorService, ITrackRepository trackRepository)
        {
            _spotifyService = spotifyService;
            _mapper = mapper;
            _spotifyLinkExtractorService = spotifyLinkExtractorService;
        }

        public async Task<SpotifyTrack> Handle(CheckTrackCommand request, CancellationToken cancellationToken)
        {
            var spotifyTrackId = await _spotifyLinkExtractorService.GetSpotifyIdFromLink(request.Link);
            var track = await _spotifyService.CheckTrackFromSpotifyId(spotifyTrackId);

            return track;
        }
    }
}
