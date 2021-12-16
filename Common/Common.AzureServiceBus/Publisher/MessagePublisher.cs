using Azure.Messaging.ServiceBus.Administration;
using Common.Model.Settings;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Common.AzureServiceBus
{
    public class MessagePublisher : IMessagePublisher
    {
        protected static string AzureServiceBusConnectionString;

        private readonly ITopicClient _topicClient;
        private readonly AzureServiceBusSettings _azureServiceBusSettings;
        public ILogger<MessagePublisher> _logger { get; }

        public MessagePublisher(ITopicClient topicClient, IOptions<AzureServiceBusSettings> azureServiceBusSettings, ILogger<MessagePublisher> logger)
        {
            _topicClient = topicClient;
            _azureServiceBusSettings = azureServiceBusSettings.Value;
            _logger = logger;

            Task.Run(EnsureTopicSubscriptionCreated);
        }

        private async Task EnsureTopicSubscriptionCreated()
        {
            _logger.LogInformation($"{this.GetType().Name}: MessagePublisher ensuring topic and subscription is created.");
            var client = new ServiceBusAdministrationClient(_azureServiceBusSettings.ConnectionString);

            if (!await client.TopicExistsAsync(_azureServiceBusSettings.TopicName))
            {
                var topicOptions = new CreateTopicOptions(_azureServiceBusSettings.TopicName);
                await client.CreateTopicAsync(topicOptions);
                _logger.LogDebug($"MessagePublisher: topic {_azureServiceBusSettings.TopicName} created.");
            }

            if (!await client.SubscriptionExistsAsync(_azureServiceBusSettings.TopicName,
                                                      _azureServiceBusSettings.SubscriptionName))
            {
                await client.CreateSubscriptionAsync(_azureServiceBusSettings.TopicName,
                                                     _azureServiceBusSettings.SubscriptionName);
                _logger.LogDebug($"MessagePublisher: subscription {_azureServiceBusSettings.SubscriptionName} created.");
            }
            _logger.LogInformation($"{this.GetType().Name}: MessagePublisher topic and subscription are created.");
        }

        public Task SendAsync<T>(T obj)
        {
            Message msg = GetMessage(obj);
            _logger.LogDebug($"MessagePublisher: SendAsync message. {(T)obj}");

            return _topicClient.SendAsync(msg);
        }

        public Task ScheduleMessageAsync<T>(T obj, DateTimeOffset dateTimeOffset)
        {
            Message msg = GetMessage(obj);
            _logger.LogDebug($"MessagePublisher: ScheduleMessageAsync message. {(T)obj} dateTimeOffset: {dateTimeOffset}");

            return _topicClient.ScheduleMessageAsync(msg, dateTimeOffset);
        }

        private static Message GetMessage<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var msg = new Message(Encoding.UTF8.GetBytes(json));
            msg.UserProperties["messageType"] = typeof(T).Name;
            return msg;
        }
    }
}