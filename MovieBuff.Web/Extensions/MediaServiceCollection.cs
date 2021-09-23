using MovieBuff;
using MovieBuff.Core.Services.LoggingService;
using MovieBuff.Core.Services.MediaService;
using MovieBuff.Infrastructure.Services.MediaService;
using MovieBuff.Services.RatingService;
using MovieBuff.Web;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediaServiceCollection
    {
        public static IServiceCollection AddMediaServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<ILoggingManager, LoggingManager>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IRatingService, RatingService>();
            return services;
        }
    }
}
