using Shared.AzureServiceBus;
using Shared.AzureServiceBus.Meta;
using Shared.Meta;
using Shared.Settings;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Shared.Extensions;

public static class ServiceBusNotificationsExtensions
{
  public static void AddServiceBusNotifications(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTIONSTRING");
    var mainTopicName = Environment.GetEnvironmentVariable("SERVICEBUS_MAINTOPIC_NAME");

    services.Configure<ServiceBusSettings>(settings =>
    {
      settings.ConnectionString = connectionString;
      settings.TopicName = mainTopicName;
    });
    services.AddSingleton<IServiceBusConnectionManager>(serviceProvider =>
    {
      var logger = serviceProvider.GetRequiredService<ILogger<ServiceBusConnectionManager>>();
      var serviceBusConnectionString = connectionString;
      var connectionStringBuilder = new ServiceBusConnectionStringBuilder(serviceBusConnectionString)
      {
        EntityPath = mainTopicName
      };
      return new ServiceBusConnectionManager(connectionStringBuilder, logger);
    });
    RegisterEventBus(services, configuration);
  }

  private static void RegisterEventBus(IServiceCollection services, IConfiguration configuration)
  {
    var subscriptionClientName = Environment.GetEnvironmentVariable("SERVICEBUS_SUBSCRIPTION_NAME");
    services.AddSingleton<IEventBusSubscriptionManager, InMemoryEventBusSubscriptionManager>();
    services.AddSingleton<IEventBus, ServiceBusEventBus>(serviceProvider =>
    {
      var serviceBusConnectionManager = serviceProvider.GetRequiredService<IServiceBusConnectionManager>();
      var logger = serviceProvider.GetRequiredService<ILogger<ServiceBusEventBus>>();
      var subscriptionManager = serviceProvider.GetRequiredService<IEventBusSubscriptionManager>();
      return new ServiceBusEventBus(serviceBusConnectionManager, subscriptionManager, subscriptionClientName,
                serviceProvider, logger);
    });
  }
}