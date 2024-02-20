namespace Shared.Settings;

public class ServiceBusSettings
{
    public required string ConnectionString { get; set; }
    public required string TopicName { get; set; }
}