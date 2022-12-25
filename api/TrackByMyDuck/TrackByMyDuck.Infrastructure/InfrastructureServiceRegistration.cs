using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackByMyDuck.Application.Services;
using TrackByMyDuck.Core.Interfaces;

namespace TrackByMyDuck.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISpotifyService, SpotifyService>();
            services.AddTransient<ISpotifyLinkExtractorService, SpotifyLinkExtractorService>();

            return services;
        }
    }
}