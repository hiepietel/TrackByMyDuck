using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Contracts.Persistence;
using TrackByMyDuck.Application.Features.Users.Commands.LogUser;
using TrackByMyDuck.Domain.Entities;

namespace TrackByMyDuck.Application.Features.Users.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, NewUserVm>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;
        public SignUpCommandHandler(IAuthService authService, IUserRepository usersRepository, IMapper mapper)
        {
            _authService = authService;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<NewUserVm> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            //string token = await _authService.CreateToken(request.Name, request.FacebookId.ToString(), request.Email);

            var user = await _usersRepository.GetByMail(request.Email);
            if (user == null)
            {
                user = await _usersRepository.AddAsync(new User
                {
                    Email = request.Email,
                    FacebookId = 0,
                    Name = request.Name,
                    ImgHref = ""
                });
            }
            var userVm = _mapper.Map<NewUserVm>(user);

            //userVm.AccessToken = token;

            return userVm;
        }
    }
}
