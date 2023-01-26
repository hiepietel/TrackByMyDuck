using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetShowTrack;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetTracks;
using TrackByMyDuck.Application.Features.Users.Commands.LogUser;
using TrackByMyDuck.Application.Models.Spotify;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SpotifyTrack, Track>();
            CreateMap<Track, ShowTrackVm>();
            CreateMap<User, UserVm>();
        }
    }
}
