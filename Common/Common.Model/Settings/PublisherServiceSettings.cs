namespace Common.Model.Settings
{
    public class PublisherServiceSettings
    {
        public const string ConfigSection = "PublisherServiceSettings";

        public int TimeIntervalInMinutes { get; set; } = 300;
    }
}
