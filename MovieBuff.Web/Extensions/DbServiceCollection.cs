using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieBuff.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbServiceCollection
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            return services;
        }
    }
}
