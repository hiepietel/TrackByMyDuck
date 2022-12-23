using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Core.Interfaces;

namespace TrackByMyDuck.Application.Features.Tracks.Commands.AddTrack
{
    internal class AddTrackCommandHandler : IRequestHandler<AddTrackCommand, bool>
    {
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;
        private readonly IMapper _mapper;

        public AddTrackCommandHandler(IConfiguration configuration, ISpotifyService spotifyService, IMapper mapper)
        {
            _configuration = configuration;
            _spotifyService = spotifyService;
            _mapper = mapper;
        }
        public Task<bool> Handle(AddTrackCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
