using MediatR;

namespace TrackByMyDuck.Application.Features.Users.Commands.SignUp
{
    public class SignUpCommand: IRequest<NewUserVm>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}