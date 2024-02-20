using Microsoft.Extensions.Options;
using PaymentService.Models;
using Shared.AzureServiceBus;
using Shared.Messages;
using Shared.Settings;

namespace PaymentService.IntergrationEvents.Events;

public class PaymentCanceledEventDispatcher : ServiceBusEventDispatcher<PaymentCanceledEvent>
{
	public PaymentCanceledEventDispatcher(IOptions<ServiceBusSettings> serviceBusOptions) : base(serviceBusOptions)
	{
	}

	// 결재 취소
	public Task DispatchAsync(Payment payment) => PublishAsync(new PaymentCanceledEvent
	{
		PaymentId = payment.Id,
		OrderId = payment.OrderId,
		Reason = "너무 비싸다"
	});
}