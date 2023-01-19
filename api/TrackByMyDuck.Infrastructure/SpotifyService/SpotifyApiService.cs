using Microsoft.Extensions.Configuration;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackByMyDuck.Infrastructure.SpotifyService
{
    internal class SpotifyApiService
    {
        private readonly IConfiguration _configuration;
        SpotifyClient _spotifyClient;
        //async public SpotifyApiService(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    var config = SpotifyClientConfig.CreateDefault();
        //    var clientId = _configuration.GetSection("Spotify:ClientId")?.Value;
        //    var clientSecret = _configuration.GetSection("Spotify:ClientSecret")?.Value;
        //    var request = new ClientCredentialsRequest(clientId, clientSecret);
        //    var response = await new OAuthClient(config).RequestToken(request);

        //    var _spotifyClient = new SpotifyClient(config.WithToken(response.AccessToken));
        //}
    }
}
