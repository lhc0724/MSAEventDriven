using InventoryService.IntergrationEvents.Events;
using InventoryService.IntergrationEvents.Handlers;
using Shared.Messages;
using Shared.Meta;

namespace InventoryService.Middlewares;

public static class ServiceBusSubscribeMiddleware
{
	public static void AddSubscribeEvents(this IApplicationBuilder app)
	{
		var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

		eventBus.Subscribe<OrderIsInProgressEvent, OrderIsInProgressEventHandler>();
		eventBus.Subscribe<PaymentCanceledEvent, PaymentCanceledEventHandler>();
	}

	public static void RegistServiceBusDependencies(this IServiceCollection services) 
	{
		#region Dispatcher

		services.AddTransient<InventoryReleaseEventDispatcher>();

		#endregion

		#region Handlers

		services.AddTransient<OrderIsInProgressEventHandler>();
		services.AddTransient<PaymentCanceledEventHandler>();

		#endregion
	}
}