using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SpotifyAPI.Web;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TrackByMyDuck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        
        public async Task<IActionResult> Login(UserSpotifyTokenDto init)
        {
            Console.WriteLine(init);

            var spotify = new SpotifyClient(init.access_token);
            var data = await spotify.UserProfile.Current();

            var token = CreateToken(data.DisplayName, init.access_token);
            var cookieOptions = new CookieOptions
            {
                //HttpOnly = true,
                Expires = DateTime.Now.AddHours(1)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
            return Ok(token);
        }


        private string CreateToken(string spotifyUserId, string spotifytoken)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, spotifyUserId),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.UserData, spotifytoken)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


    }

    public class UserSpotifyTokenDto
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
    }
}
