using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TrackByMyDuck.Application.Features.Users.Commands.LogUser
{

    public class LogUserCommand: IRequest<UserVm>
    {
        public string? Email { get; set; }

        [Required]
        public string? Provider { get; set; }

        [Required]
        public string? AccessToken { get; set; }

        [Required]
        public string? Name { get; set; }
        public int FacebookId { get; set; }
        public string ImgHref { get; set; }
    }
}