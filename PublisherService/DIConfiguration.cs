using Common.AzureServiceBus;
using Common.Logger;
using Common.Model.Settings;
using Common.Repository;
using Common.Repository.DataRepository;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace PublisherService
{
    public class DIConfiguration
    {
        public ServiceProvider provider;
        public IHostBuilder CreateHostBuilder(string[] args, IConfiguration config) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => ConfigureServices(services, config));

        public IConfigurationBuilder BuildConfig()
        {
            var builder = new ConfigurationBuilder();
            return builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("RUNTIME_ENVIRONMENT") ?? "PROD"}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ILoggingService, LoggingService>()
                    .Configure<AzureServiceBusSettings>(config.GetSection(AzureServiceBusSettings.ConfigSection))
                    .Configure<PublisherServiceSettings>(config.GetSection(PublisherServiceSettings.ConfigSection))
                    .Configure<SqlConnectionsSetting>(config.GetSection(SqlConnectionsSetting.ConfigSection))
                    .AddScoped<IMessagePublisher, MessagePublisher>()
                    .AddScoped<IDataConnection, DataConnection>()
                    .AddScoped<IDataRepository, DataRepository>();

            services.AddSingleton<ITopicClient>(x =>
                new TopicClient(
                    connectionString: config.GetSection($"{AzureServiceBusSettings.ConfigSection}:ConnectionString").Value,
                    entityPath: config.GetSection($"{AzureServiceBusSettings.ConfigSection}:TopicName").Value
                )
            );

            services.AddHostedService<Common.Services.PublisherService>();

            provider = services.BuildServiceProvider();
        }
    }
}
