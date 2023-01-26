using AutoMapper;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetTracks;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
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


                
        }    
    }
}