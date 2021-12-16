namespace Common.Model.Settings
{
    public class AzureServiceBusSettings
    {
        public const string ConfigSection = "AzureServiceBusSettings";
        public string ConnectionString { get; set; }
        public string TopicName { get; set; }
        public string SubscriptionName { get; set; }
    }
}
