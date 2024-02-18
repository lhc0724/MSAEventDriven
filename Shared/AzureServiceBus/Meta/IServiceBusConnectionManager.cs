using Microsoft.Azure.ServiceBus;

namespace Shared.AzureServiceBus.Meta;

public interface IServiceBusConnectionManager : IDisposable
{
    ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder { get; }
    ITopicClient CreateTopicClient();
}