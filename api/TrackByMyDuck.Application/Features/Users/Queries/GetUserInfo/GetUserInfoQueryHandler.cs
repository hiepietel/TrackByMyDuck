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

namespace TrackByMyDuck.Application.Features.Users.Queries.GetUserInfo
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserInfoVm>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _usersRepository;
        private readonly IMapper _mapper;

        public GetUserInfoQueryHandler(IAuthService authService, IUserRepository usersRepository, IMapper mapper)
        {
            _authService = authService;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserInfoVm> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var data = await _authService.GetUserInfo();
            var user = await _usersRepository.GetByMail(data);
            if (user == null)
            {
                //unathorized
                return new UserInfoVm();
            }
            return new UserInfoVm()
            {
                Name = user.Name,
                Email = user.Email,
                ImgHref = user.ImgHref         
            };
        }
    }
}
