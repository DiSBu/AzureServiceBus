namespace Common.Model.Settings
{
    public class ConsumerServiceSettings
    {
        public const string ConfigSection = "ConsumerServiceSettings";

        public string JWTEncryptionKey { get; set; }
        public string ExpireToken { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ApiUrl { get; set; }
    }
}
