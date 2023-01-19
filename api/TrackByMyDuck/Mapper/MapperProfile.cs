using AutoMapper;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetShowTrack;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetTracks;
using TrackByMyDuck.Application.Models.Spotify;
using TrackByMyDuck.Domain.Entities;
using TrackByMyDuck.Dtos;

namespace TrackByMyDuck.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<SpotifyTrack, SpotifyTrackDto>();
            CreateMap<Track, ShowTrackVm>();
            CreateMap<Track, TrackVm>()
                .ForMember(x => x.ImgHref, y => y.MapFrom(x => x.Album.ImgHref))
                .ForMember(z => z.Artists, x => x.MapFrom(x => x.TrackArtists.Select(x => x.Artist.Name)));
                
        }    
    }
}