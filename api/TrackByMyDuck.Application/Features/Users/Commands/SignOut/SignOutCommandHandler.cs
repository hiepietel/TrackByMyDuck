using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Application.Features.Users.Commands.SignOut
{
    internal class SignOutCommandHandler : IRequestHandler<SignOutCommand>
    {
        public Task<Unit> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
