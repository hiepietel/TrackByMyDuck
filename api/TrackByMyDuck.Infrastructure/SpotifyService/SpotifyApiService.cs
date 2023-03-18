using Microsoft.Extensions.Configuration;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Models.Spotify;

namespace TrackByMyDuck.Infrastructure.SpotifyService
{
    public class SpotifyApiService: ISpotifyApiService
    {
        private readonly IConfiguration _configuration;

        public SpotifyApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<FullTrack> GetTrackBySpotyfiyId(string spotifyTrackId)
        {
            var spotify = await CreateSpotifyClient();

            var spotifyTrack = await spotify.Tracks.Get(spotifyTrackId);
            return spotifyTrack;
        }
        
        private async Task<SpotifyClient> CreateSpotifyClient()
        {
            var config = SpotifyClientConfig.CreateDefault();
            var clientId = _configuration.GetSection("Spotify:ClientId")?.Value;
            var clientSecret = _configuration.GetSection("Spotify:ClientSecret")?.Value;
            var request = new ClientCredentialsRequest(clientId, clientSecret);
            var response = await new OAuthClient(config).RequestToken(request);

            return new SpotifyClient(config.WithToken(response.AccessToken));
        }
    }
}
