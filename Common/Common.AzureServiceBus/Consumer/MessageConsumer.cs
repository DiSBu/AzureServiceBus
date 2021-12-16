using Common.AzureServiceBus.Consumer;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.AzureServiceBus
{
    public class MessageConsumer<TMessage, TMessageProcessorException> : BackgroundService
    {
        public ISubscriptionClient _subscriptionClient { get; }
        public IMessageProcessor<TMessage> _messageProcessor { get; }
        public IMessageExceptionHandler<TMessage, TMessageProcessorException> _messageExceptionHandler { get; }
        public ILogger<MessageConsumer<TMessage, TMessageProcessorException>> _logger { get; }

        public MessageConsumer(ISubscriptionClient subscriptionClient, IMessageProcessor<TMessage> messageProcessor, IMessageExceptionHandler<TMessage, TMessageProcessorException> messageExceptionHandler, ILogger<MessageConsumer<TMessage, TMessageProcessorException>> logger )
        {
            _subscriptionClient = subscriptionClient;
            _messageProcessor = messageProcessor;
            _messageExceptionHandler = messageExceptionHandler;
            _logger = logger;
            _logger.LogInformation($"{this.GetType().Name}: Adding a MessageConsumer for SubscriptionClient Path: {_subscriptionClient.Path} Endpoint: {_subscriptionClient.ServiceBusConnection.Endpoint.AbsoluteUri.ToString()}.");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _logger.LogDebug($"{this.GetType().Name}: MessageConsumer registering MessageHandler.");
            _subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
            _logger.LogDebug($"{this.GetType().Name}: MessageConsumer MessageHandler registered correctly.");

            return Task.CompletedTask;
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            _logger.LogDebug($"{this.GetType().Name}: Message received: {Encoding.UTF8.GetString(message.Body)}");
            var obj = JsonConvert.DeserializeObject<TMessage>(Encoding.UTF8.GetString(message.Body));
            try
            {
                _logger.LogDebug($"{this.GetType().Name}: Processing message: {obj.GetType()}");
                _messageProcessor.ProcessMessage(obj);
            }
            catch(Exception ex)
            {
                _logger.LogError($"{this.GetType().Name}: Handling exception on message processing. {ex.Message} : {ex.StackTrace}");
                _messageExceptionHandler.HandleException<TMessageProcessorException>(ex);
            }
            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            _logger.LogDebug($"{this.GetType().Name}:Message processed.");
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs ex)
        {
            _logger.LogError($"{this.GetType().Name}: Message exception: {ex.Exception.Message} - {ex.Exception.StackTrace}");
            return Task.FromException(ex.Exception);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{this.GetType().Name}: Message consumer started.");

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _subscriptionClient.CloseAsync();
            _logger.LogInformation($"{this.GetType().Name}: Message consumer stoped.");
        }
    }
}