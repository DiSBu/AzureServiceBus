using Common.Logger;
using Common.Model.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Common.Services.Tests
{
    public static class TestStartup
    {
        public static IServiceProvider ServiceProvider;

        public static void ConfigureServices(IServiceCollection services)
        {
            var builder = BuildConfig();
            IConfiguration config = builder.Build();
            
            services.AddScoped<ILoggingService, LoggingService>()
                    .AddOptions()
                    .AddSingleton(config)
                    .Configure<AzureServiceBusSettings>(config.GetSection(AzureServiceBusSettings.ConfigSection))
                    .Configure<ConsumerServiceSettings>(config.GetSection(ConsumerServiceSettings.ConfigSection))
                    .Configure<PublisherServiceSettings>(config.GetSection(PublisherServiceSettings.ConfigSection))
                    .Configure<SqlConnectionsSetting>(config.GetSection(SqlConnectionsSetting.ConfigSection))
                    .AddScoped<IPublisherService, PublisherService>()
                    .Add(ServiceDescriptor.Describe(typeof(ILogger<>), typeof(Logger<>), ServiceLifetime.Scoped));

            ServiceProvider = services.BuildServiceProvider();
        }

        public static IConfigurationBuilder BuildConfig()
        {
            var builder = new ConfigurationBuilder();
            return builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }

        public static void DisposeServices()
        {
            if (ServiceProvider == null)
            {
                return;
            }

            if (ServiceProvider is IDisposable)
            {
                ((IDisposable)ServiceProvider).Dispose();
            }
        }
    }
}