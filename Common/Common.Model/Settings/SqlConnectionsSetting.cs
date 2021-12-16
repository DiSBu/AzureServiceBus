namespace Common.Model.Settings
{
    public class SqlConnectionsSetting
    {
        public const string ConfigSection = "SqlConnections";

        public string ConnectionString { get; set; }
        public WebsiteConnStringOptions Website { get; set; }
    }

    public class WebsiteConnStringOptions
    {
        public string ConnectionString { get; set; }
    }
}