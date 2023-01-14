using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Contracts.Persistence
{
    public interface ITrackRepository: IAsyncRepository<Track>
    {
        Task<Track> GetShowTrack();
    }
}