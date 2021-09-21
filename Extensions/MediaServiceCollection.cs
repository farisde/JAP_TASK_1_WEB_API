using MovieBuff.Services.MovieService;
using MovieBuff;
using MovieBuff.Services.RatingService;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediaServiceCollection
    {
        public static IServiceCollection AddMediaServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IRatingService, RatingService>();
            return services;
        }
    }
}
