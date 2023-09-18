using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Services;
using TrackByMyDuck.Core.Interfaces;
using TrackByMyDuck.Infrastructure.AuthenticationService;
using TrackByMyDuck.Infrastructure.SpotifyService;
using TrackByMyDuck.Infrastructure.UserService;

namespace TrackByMyDuck.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHttpContextAccessor();

            services.AddTransient<ISpotifyService, Application.Services.SpotifyService>();
            services.AddTransient<ISpotifyLinkExtractorService, SpotifyLinkExtractorService>();
            services.AddTransient<ISpotifyApiService, SpotifyApiService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserTrackService, UserTrackService>();

            return services;
        }
    }
}