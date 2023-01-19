using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Models.Authentication;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IHttpClientFactory httpClientFactory, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [Route("facebook-login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> FacebookLogin([FromBody] SocialLoginRequest obj)
        {
            var token = await _authService.SocialLogin(obj);
            return Ok(token);
        }
    }
}