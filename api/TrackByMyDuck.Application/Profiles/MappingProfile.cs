using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Features.Tracks.Commands.AddTrack;
using TrackByMyDuck.Application.Features.Tracks.Commands.CheckTrack;
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
            CreateMap<UserTrack, TrackVm>()
                .ForMember(x => x.SpotifyTrackId, y => y.MapFrom(x => x.Track.SpotifyId))
                .ForMember(x => x.PreviewUrl, y => y.MapFrom(x => x.Track.PreviewUrl))
                .ForMember(x => x.TrackName, u => u.MapFrom(c => c.Track.Name))
                .ForMember(x => x.ImgHref, y => y.MapFrom(x => x.Track.Album.ImgHref))
                .ForMember(z => z.Artists, x => x.MapFrom(x => x.Track.TrackArtists.Select(x => x.Artist.Name)))
                .ForMember(n => n.ImgHref, m => m.MapFrom(x => x.Track.Album.ImgHref)) // 
                .ForMember(c => c.UserId, v => v.MapFrom(v => v.User.Id))
                .ForMember(c => c.UserName, v => v.MapFrom(v => v.User.Name));

            CreateMap<Track, AddTrackVm>()
                .ForMember(x => x.SpotifyTrackId, y => y.MapFrom(x => x.SpotifyId))
                .ForMember(x => x.PreviewUrl, y => y.MapFrom(x => x.PreviewUrl))
                .ForMember(x => x.TrackName, y => y.MapFrom(x => x.Name));

            CreateMap<SpotifyTrack, CheckTrackVm>()
                .ForMember(x => x.SpotifyTrackId, y => y.MapFrom(x => x.SpotifyId))
                .ForMember(x => x.PreviewUrl, y => y.MapFrom(x => x.PreviewUrl))
                .ForMember(x => x.TrackName, y => y.MapFrom(x => x.Name));
            

            CreateMap<Track, SpotifyTrack>()
                .ForMember(z => z.PreviewUrl, y => y.MapFrom(x => x.PreviewUrl));
            CreateMap<Track, ShowTrackVm>();
            CreateMap<User, UserVm>();
        }
    }
}
