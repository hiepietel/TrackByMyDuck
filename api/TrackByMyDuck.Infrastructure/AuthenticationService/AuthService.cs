using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Models.Authentication;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TrackByMyDuck.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace TrackByMyDuck.Infrastructure.AuthenticationService
{
    public class AuthService: IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContexAccessor;

        public AuthService(IConfiguration configuration, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory; 
            _httpContexAccessor = httpContextAccessor;
        }

        public async Task<bool> ValidateFacebookToken(string accessToken)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var appAccessTokenResponse = await httpClient.GetFromJsonAsync<FacebookAppAccessTokenResponse>($"https://graph.facebook.com/oauth/access_token?client_id={_configuration["Facebook:ClientId"]}&client_secret={_configuration["Facebook:ClientSecret"]}&grant_type=client_credentials");
            var response = await httpClient.GetFromJsonAsync<FacebookTokenValidationResult>($"https://graph.facebook.com/debug_token?input_token={accessToken}&access_token={appAccessTokenResponse!.AccessToken}");

            if (response is null || !response.Data.IsValid)
            {
                //return Result.Fail($"{request.Provider} access token is not valid.");
                return false;
            }

            //return Result.Ok();
            return true;
        }


        public async Task<string> CreateToken(string name, string id, string email)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Name, name)
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

        public async Task<string> GetUserInfo()
        {
            var result = string.Empty;
            if (_httpContexAccessor.HttpContext != null)
            {
                result = _httpContexAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            }
            return result;
        }

        //private void SetRefreshToken(RefreshToken newRefreshToken)
        //{
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = newRefreshToken.Expires
        //    };
        //    Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);
        //}
    }
}
