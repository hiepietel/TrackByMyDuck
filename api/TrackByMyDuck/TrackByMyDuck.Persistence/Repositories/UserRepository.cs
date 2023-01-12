using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Persistence.Repositories
{
    public class UserRepository : BaseRepository<Track>, IUserRepository
    {
        public UserRepository(TrackByMyDuckContext dbContext) : base(dbContext)
        {
        }
    }
}
