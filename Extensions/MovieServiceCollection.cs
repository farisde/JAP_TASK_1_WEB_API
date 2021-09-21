using MovieBuff.Services.MovieService;
using MovieBuff;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MovieServiceCollection
    {
        public static IServiceCollection AddMovieServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IMovieService, MovieService>();
            return services;
        }
    }
}
