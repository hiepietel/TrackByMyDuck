using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Application.Features.Tracks.Queries.GetShowTrack;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Features.Users.Commands.LogUser
{
    public class LogUserCommandHandler : IRequestHandler<LogUserCommand, UserVm>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;
        public LogUserCommandHandler(IAuthService authService, IUserRepository usersRepository, IMapper mapper)
        {
            _authService = authService;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserVm> Handle(LogUserCommand request, CancellationToken cancellationToken)
        {

            //_authService.ValidateFacebookToken()

            string token = await _authService.CreateToken(request.Name, request.FacebookId.ToString(), request.Email);

            var user = await _usersRepository.GetByMail(request.Email);
            if (user == null)
            {
                user = await _usersRepository.AddAsync(new User
                {
                    Email = request.Email,
                    FacebookId = request.FacebookId,
                    Name = request.Name,
                    ImgHref = request.ImgHref
                });
            }
            var userVm = _mapper.Map<UserVm>(user);
            
            userVm.AccessToken = token;
            
            return userVm;
        }
    }
}
