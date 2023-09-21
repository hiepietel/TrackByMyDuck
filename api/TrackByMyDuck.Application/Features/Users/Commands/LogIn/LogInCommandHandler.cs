using AutoMapper;
using MediatR;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Contracts.Persistence;

namespace TrackByMyDuck.Application.Features.Users.Commands.LogUser
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, LogInUserVm>
    {
        private readonly IAuthService _authService;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;
        public LogInCommandHandler(IAuthService authService, IUserRepository usersRepository, IMapper mapper, IPasswordService passwordService)
        {
            _authService = authService;
            _usersRepository = usersRepository;
            _mapper = mapper;
            _passwordService = passwordService;
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
            var pass = _passwordService.ValidatePassword(request.Password, user.Hash, user.Salt);
            if(pass == false)
            {
                throw new Exception("pass == false");
            }

            var userVm = _mapper.Map<LogInUserVm>(user);
            
            userVm.AccessToken = token;
            
            return userVm;
        }
    }
}
