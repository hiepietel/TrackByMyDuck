using Microsoft.EntityFrameworkCore;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TrackByMyDuckContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByMail(string email)
        {
           var data = await _dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return data;
        }

        public async Task<User> GetByName(string name)
        {
            var data = await _dbContext.Users.Where(x => x.Name == name).FirstOrDefaultAsync();
            return data;
        }
    }
}