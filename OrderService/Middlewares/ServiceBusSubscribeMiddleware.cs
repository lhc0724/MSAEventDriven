using OrderService.IntergrationEvents.EventHandlers;
using OrderService.IntergrationEvents.Events;
using OrderService.IntergrationEvents.Handlers;
using Shared.Messages;
using Shared.Meta;

namespace MailService.Middlewares;

public static class ServiceBusSubscribeMiddleware
{
	public static void AddSubscribeEvents(this IApplicationBuilder app)
	{
		var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

		eventBus.Subscribe<InventoryReleaseEvent, InventoryReleaseEventHandler>();
		eventBus.Subscribe<PaymentCompletedEvent, PaymentCompletedEventHandler>();
	}

	public static void RegistServiceBusDependencies(this IServiceCollection services) 
	{
		#region Dispatcher

		services.AddTransient<OrderIsInProgressEventDispatcher>();

		#endregion

		#region Handlers

		services.AddTransient<InventoryReleaseEventHandler>();
		services.AddTransient<PaymentCompletedEventHandler>();

		#endregion
	}
}