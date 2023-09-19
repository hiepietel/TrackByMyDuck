using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Features.Users.Commands.LogUser;

namespace TrackByMyDuck.Application.Features.Users.Commands.SignUp
{
    public class SignUpCommand: IRequest<NewUserVm>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
