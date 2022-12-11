using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrackByMyDuck.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TruckByMyDuckContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(""))
             );
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IEventRepository, EventRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
