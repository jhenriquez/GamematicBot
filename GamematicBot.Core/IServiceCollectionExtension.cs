using GamematicBot.Core.Queries;
using GamematicBot.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GamematicBot.Core {
    public static class IServiceCollectionExtension {
        public static IServiceCollection AddGamematicBotCore(this IServiceCollection services) {
            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces());

            services.AddHttpClient<IIGDBService, IGDBService>();
            
            return services;
        }
    }
}