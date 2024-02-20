using MailService.IntergrationEvents.Handlers;
using Shared.Messages;
using Shared.Meta;

namespace MailService.Middlewares;

public static class ServiceBusSubscribeMiddleware
{
	public static void AddSubscribeEvents(this IApplicationBuilder app)
	{
		var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

		eventBus.Subscribe<PaymentCompletedEvent, PaymentCompletedEventHandler>();
		eventBus.Subscribe<PaymentCanceledEvent, PaymentCanceledEventHandler>();
	}

	public static void RegistServiceBusDependencies(this IServiceCollection services) 
	{
		#region Dispatcher

		#endregion

		#region Handlers

		services.AddTransient<PaymentCompletedEventHandler>();
		services.AddTransient<PaymentCanceledEventHandler>();

		#endregion
	}
}