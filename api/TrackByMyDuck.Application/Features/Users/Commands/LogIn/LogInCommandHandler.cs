﻿using AutoMapper;
using MediatR;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Contracts.Persistence;

namespace TrackByMyDuck.Application.Features.Users.Commands.LogUser
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, LogInUserVm>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;
        public LogInCommandHandler(IAuthService authService, IUserRepository usersRepository, IMapper mapper)
        {
            _authService = authService;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<LogInUserVm> Handle(LogInCommand request, CancellationToken cancellationToken)
        {

            //_authService.ValidateFacebookToken()

            string token = await _authService.CreateToken(request.Name, request.Name.ToString(), request.Name);

            var user = await _usersRepository.GetByName(request.Name);
            if (user == null)
            {
                throw new Exception(":)");
            }
            var userVm = _mapper.Map<LogInUserVm>(user);
            
            userVm.AccessToken = token;
            
            return userVm;
        }
    }
}
