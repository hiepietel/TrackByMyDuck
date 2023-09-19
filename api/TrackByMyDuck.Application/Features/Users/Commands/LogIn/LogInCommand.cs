using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TrackByMyDuck.Application.Features.Users.Commands.LogUser
{

    public class LogInCommand : IRequest<LogInUserVm>
    {
        public string Name { get; set; }
    }
}