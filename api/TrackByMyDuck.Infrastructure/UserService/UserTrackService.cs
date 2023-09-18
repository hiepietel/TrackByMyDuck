using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Domain.Entities;
using TrackByMyDuck.Infrastructure.AuthenticationService;

namespace TrackByMyDuck.Infrastructure.UserService
{
    public class UserTrackService : IUserTrackService
    {
        private readonly IUserTrackRepository _userTrackRepository;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public UserTrackService(IUserTrackRepository userTrackRepository, IAuthService authService, IUserRepository userRepository)
        {
            _userTrackRepository = userTrackRepository;
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<bool> CreateFromTrack(int trackId)
        {
            var data = await _authService.GetUserInfo();
            var user = await _userRepository.GetByMail(data);
            if(user == null)
            {
                return false;
            }
            await _userTrackRepository.AddAsync(new UserTrack()
            {
                CreatedDate = DateTime.Now,
                TrackId = trackId,
                UserId = user.Id,
            });
            return true;
        }
    }
}
