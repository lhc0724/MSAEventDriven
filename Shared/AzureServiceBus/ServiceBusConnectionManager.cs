using Shared.AzureServiceBus.Meta;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;

namespace Shared.AzureServiceBus;

public class ServiceBusConnectionManager : IServiceBusConnectionManager
{
    private readonly ILogger<ServiceBusConnectionManager> _logger;
    private readonly ServiceBusConnectionStringBuilder _connectionStringBuilder;
    private ITopicClient _topicClient;

    public ServiceBusConnectionManager(ServiceBusConnectionStringBuilder serviceBusConnectionStringBuilder,
        ILogger<ServiceBusConnectionManager> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _connectionStringBuilder = serviceBusConnectionStringBuilder ??
                                   throw new ArgumentNullException(nameof(serviceBusConnectionStringBuilder));
        _topicClient = new TopicClient(_connectionStringBuilder, RetryPolicy.Default);
    }

    public ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder => _connectionStringBuilder;

    public ITopicClient CreateTopicClient()
    {
        if(_topicClient.IsClosedOrClosing)
            _topicClient = new TopicClient(_connectionStringBuilder, RetryPolicy.Default);

        return _topicClient;
    }

    public void Dispose(){
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;
        _topicClient.CloseAsync().Wait();
    }
}