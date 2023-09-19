using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Models.Authentication;
using MediatR;
using TrackByMyDuck.Application.Features.Users.Commands.LogUser;
using TrackByMyDuck.Application.Features.Users.Queries.GetUserInfo;
using TrackByMyDuck.Application.Features.Users.Commands.SignUp;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("facebook-login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> FacebookLogin([FromBody] FacebookLogInCommand obj)
        {
            var token = await _mediator.Send(obj);
            return Ok(token);
        }        
        
        [Route("sign-in")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] LogInCommand obj)
        {
            var token = await _mediator.Send(obj);
            return Ok(token);
        }

        [Route("sign-up")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SingUp([FromBody] SignUpCommand obj)
        {
            var token = await _mediator.Send(obj);
            return Ok(token);
        }


        [Route("user-info")]
        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            var token = await _mediator.Send(new GetUserInfoQuery());
            return Ok(token);
        }
    }
}