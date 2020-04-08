using System.Reflection;
using GamematicBot.Core.Models;
using GamematicBot.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

[assembly: TestFramework("GamematicBot.Core.Test.Startup", "GamematicBot.Core.Test")]
namespace GamematicBot.Core.Test
{
    public class Startup : DependencyInjectionTestFramework
    {
        private IConfiguration Configuration;

        public Startup(IMessageSink messageSink) : base(messageSink) {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<Startup>()
                .Build();   
        }

        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<GamematicBotSettings>(Configuration.GetSection("GamematicBot"));
            services.AddGamematicBotCore();

            var FakeIGDBService = Substitute.For<IIGDBService>();
            
            var IGDBServiceDescriptor = new ServiceDescriptor(
                typeof(IIGDBService),
                FakeIGDBService);

            services.Replace(IGDBServiceDescriptor);
        }

        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>
            base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);
    }
}