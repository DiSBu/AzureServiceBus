using Common.AzureServiceBus;
using Common.Logger;
using Common.Model.MessageModels;
using Common.Model.Settings;
using Common.Repository.DataRepository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Services
{
    public class PublisherService : IHostedService, IDisposable, IPublisherService
    {
        private ILoggingService _logger;
        private Timer _timer;
        private readonly IOptionsMonitor<PublisherServiceSettings> _publisherServiceSettings;
        private bool isRunning = false;
        private readonly IMessagePublisher _messagePublisher;
        private IDataRepository _dataRepository;

        public PublisherService(ILoggingService logger, IOptionsMonitor<PublisherServiceSettings> publisherServiceSettings, IMessagePublisher messagePublisher, IDataRepository dataRepository)
        {
            _logger = logger;
            _publisherServiceSettings = publisherServiceSettings;
            _messagePublisher = messagePublisher;
            _dataRepository = dataRepository;

            _logger.LogInformation("PublisherService is Created");
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"PublisherService is Starting. Configured to run every { _publisherServiceSettings.CurrentValue.TimeIntervalInMinutes } minute(s)");
            _timer = new Timer(Process, null, TimeSpan.Zero, TimeSpan.FromMinutes(_publisherServiceSettings.CurrentValue.TimeIntervalInMinutes));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("PublisherService is Stopping");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Process(object state)
        {
            if (isRunning)
            {
                _logger.LogInformation("PublisherService is skipping this run. Old process is still running.");
                return;
            }

            isRunning = true;
            _logger.LogInformation("PublisherService is starting a new process.");

            try
            {
                _logger.LogInformation($"PublisherService sending AzureMessage.");
                //Publish any mesage here
                Random rd = new Random();
                int rand_num = rd.Next(100, 200);
                _messagePublisher.SendAsync(new AzureMessage() { Id = rand_num});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{ this.GetType().Name}: Exception when Processing.");
            }

            _logger.LogInformation("PublisherService process has finished.");
            isRunning = false;
        }
    }
}