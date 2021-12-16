using Common.AzureServiceBus;
using Common.AzureServiceBus.Consumer;
using Common.ApiService;
using Common.Logger;
using Common.Model.Exceptions;
using Common.Model.MessageModels;
using Common.Model.Settings;
using Common.Repository;
using Common.Repository.DataRepository;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace ConsumerService
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
                    .Configure<ConsumerServiceSettings>(config.GetSection(ConsumerServiceSettings.ConfigSection))
                    .Configure<SqlConnectionsSetting>(config.GetSection(SqlConnectionsSetting.ConfigSection))
                    .AddSingleton<IMessageProcessor<AzureMessage>, AzureMessageProcessor>()
                    .AddScoped<IMessageExceptionHandler<AzureMessage, AzureMessageProcessorException>, AzureMessageExceptionHandler>()
                    .AddScoped<IMessagePublisher, MessagePublisher>()
                    .AddScoped<IDataConnection, DataConnection>()
                    .AddScoped<IDataRepository, DataRepository>()
                    .AddScoped<ITokenCreationHandler, TokenCreationHandler>()
                    .AddScoped<IApiService, ApiService>()
                    .AddSingleton<ISubscriptionClient>(serviceProvider =>
                        new SubscriptionClient(
                           connectionString: config.GetSection($"{AzureServiceBusSettings.ConfigSection}:ConnectionString").Value,
                           topicPath: config.GetValue<string>($"{AzureServiceBusSettings.ConfigSection}:TopicName"),
                           subscriptionName: config.GetValue<string>($"{AzureServiceBusSettings.ConfigSection}:SubscriptionName")))
                    .AddHostedService<MessageConsumer<AzureMessage, AzureMessageProcessorException>>();     

            provider = services.BuildServiceProvider();
        }
    }
}
