using Microsoft.Extensions.Options;
using PaymentService.Models;
using Shared.AzureServiceBus;
using Shared.Messages;
using Shared.Settings;

namespace PaymentService.IntergrationEvents.Events;

public class PaymentCompletedEventDispatcher : ServiceBusEventDispatcher<PaymentCompletedEvent>
{
	public PaymentCompletedEventDispatcher(IOptions<ServiceBusSettings> serviceBusOptions) : base(serviceBusOptions)
	{
	}

	public Task DispatchAsync(Payment payment) => PublishAsync(new PaymentCompletedEvent
	{
		PaymentId = payment.Id,
		OrderId = payment.OrderId
	});
}