using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Models.Authentication;

namespace TrackByMyDuck.Application.Contracts.Infrastructure
{
    public interface IAuthService
    {
        Task<string> SocialLogin(SocialLoginRequest request);
    }
}
