namespace ComponentConsumption.Model.SettingsExtensions
{
    public class RabbitMqSettings
    {
        public string HostName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty ;

        public int RetryCount { get; set; } = 10;
        public int RetryBaseDelaySeconds { get; set; } = 2;
    }
}
