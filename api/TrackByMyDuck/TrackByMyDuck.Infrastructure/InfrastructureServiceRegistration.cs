using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackByMyDuck.Application.Contracts.Infrastructure;
using TrackByMyDuck.Application.Services;
using TrackByMyDuck.Core.Interfaces;
using TrackByMyDuck.Infrastructure.AuthenticationService;

namespace TrackByMyDuck.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISpotifyService, Application.Services.SpotifyService>();
            services.AddTransient<ISpotifyLinkExtractorService, SpotifyLinkExtractorService>();
            services.AddTransient<IAuthService, AuthService>();

            return services;
        }
    }
}