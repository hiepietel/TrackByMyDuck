using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetByMail(string email);
    }
}