using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackByMyDuck.Persistence.Repositories;
using TrackByMyDuck.Application.Contracts.Persistence;

namespace TrackByMyDuck.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (false) //no db
            {
                services.AddDbContext<TrackByMyDuckContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("TrackByMyDuckDatabase"), b => b.MigrationsAssembly("TrackByMyDuck"))
                );
            }
            else
            {
                services.AddDbContext<TrackByMyDuckContext>
                    (o => o.UseInMemoryDatabase("MyDatabase"));
            }

            services.AddDbContext<TrackByMyDuckContext>
                    (o => o.UseInMemoryDatabase("MyDatabase"));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<ITrackArtistRepository, TrackArtistRepository>();
            services.AddScoped<IUserTrackRepository, UserTrackRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
