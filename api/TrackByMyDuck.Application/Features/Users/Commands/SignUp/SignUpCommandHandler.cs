using AutoMapper;
using MediatR;
using System.Reflection.Metadata.Ecma335;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Features.Users.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, NewUserVm>
    {
        private readonly IAuthService _authService;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;
        public SignUpCommandHandler(IAuthService authService, IUserRepository usersRepository, IMapper mapper, IPasswordService passwordService)
        {
            _authService = authService;
            _passwordService = passwordService;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<NewUserVm> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            //string token = await _authService.CreateToken(request.Name, request.FacebookId.ToString(), request.Email);

            var user = await _usersRepository.GetByMail(request.Email);
            if (user == null)
            {
                var hash = _passwordService.EncryptPassword(request.Password);

                var passwordValidated = _passwordService.ValidatePassword(request.Password, hash.Item1, hash.Item2);
                if(passwordValidated == false)
                {
                    return null;
                }
                Console.WriteLine(hash);
                user = await _usersRepository.AddAsync(new User
                {
                    Email = request.Email,
                    FacebookId = 0,
                    Name = request.Name,
                    ImgHref = "",
                    Hash = hash.Item1,
                    Salt = hash.Item2
                });
            }
            else
            {
                return null;
            }
            var userVm = _mapper.Map<NewUserVm>(user);

            //userVm.AccessToken = token;

            return userVm;
        }
    }
}
