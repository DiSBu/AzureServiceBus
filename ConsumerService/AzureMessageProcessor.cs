using Common.AzureServiceBus.Consumer;
using Common.ApiService;
using Common.Logger;
using Common.Model.Exceptions;
using Common.Model.MessageModels;
using System;

namespace ConsumerService
{
    public class AzureMessageProcessor : MessageProcessor<AzureMessage>
    {
        private IApiService _apiService;
        public ILoggingService _logger { get; }

        public AzureMessageProcessor(IApiService apiService, ILoggingService logger)
        {
            _apiService = apiService;
            _logger = logger;
            _logger.LogInformation($"AzureMessageProcessor is started.");
        }

        public override void ProcessMessage(AzureMessage msg)
        {
            _logger.LogDebug($"{this.GetType().FullName}: Received message Id: {msg.Id}");
            try
            {
                _logger.LogDebug($"{this.GetType().FullName}: Processing message Id: {msg.Id}");
                _apiService.CallApiEndpoint(msg);

                _logger.LogDebug($"{this.GetType().FullName}: Finish processing message Id: {msg.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().FullName}: Exception was thrown when processing message Id: {msg.Id} Message: {ex.Message}");
                throw new AzureMessageProcessorException(ex);
            }
        }
    }
}