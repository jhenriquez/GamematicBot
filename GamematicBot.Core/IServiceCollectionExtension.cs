using GamematicBot.Core.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace GamematicBot.Core {
    public static class IServiceCollectionExtension {
        public static IServiceCollection AddGamematicBotCore(this IServiceCollection services) {
            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces());
            return services;
        }
    }
}