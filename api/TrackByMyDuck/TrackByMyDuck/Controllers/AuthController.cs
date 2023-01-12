using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
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
            await _authService.SocialLogin(obj);
            return Ok(true);
        }


        [Route("facebook-response")]
        [HttpGet]
        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });

            return Ok(claims);
        }
    }
}
