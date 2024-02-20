using PaymentService.IntergrationEvents.Events;

namespace PaymentService.Middlewares;

public static class ServiceBusSubscribeMiddleware
{
	public static void AddSubscribeEvents(this IApplicationBuilder app)
	{
	}

	public static void RegistServiceBusDependencies(this IServiceCollection services) 
	{
		#region Dispatcher

		services.AddTransient<PaymentCanceledEventDispatcher>();
		services.AddTransient<PaymentCompletedEventDispatcher>();

		#endregion

		#region Handlers

		#endregion
	}
}