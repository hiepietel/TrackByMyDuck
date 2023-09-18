using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Contracts.Persistence
{
    public interface IUserTrackRepository : IAsyncRepository<UserTrack>
    {
        Task<List<UserTrack>> ListAllWithAdditionalData();
    }
}