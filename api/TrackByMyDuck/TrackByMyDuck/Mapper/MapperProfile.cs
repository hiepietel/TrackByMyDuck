using AutoMapper;
using TrackByMyDuck.Core.SpotifyEntities;
using TrackByMyDuck.Dtos;

namespace TrackByMyDuck.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<SpotifyTrack, SpotifyTrackDto>();
           // CreateMap<ShowTr, SpotifyTrackDto>();
        }
        
    }
}
