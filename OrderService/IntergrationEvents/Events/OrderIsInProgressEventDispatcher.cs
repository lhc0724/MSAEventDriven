using Microsoft.Extensions.Options;
using OrderService.Models;
using Shared.AzureServiceBus;
using Shared.Messages;
using Shared.Settings;

namespace OrderService.IntergrationEvents.Events;

public class OrderIsInProgressEventDispatcher : ServiceBusEventDispatcher<OrderIsInProgressEvent>
{
	public OrderIsInProgressEventDispatcher(IOptions<ServiceBusSettings> serviceBusOptions) : base(serviceBusOptions)
	{
	}

	// 주문 접수 완료 이벤트 게시
	public Task DispatchAsync(Order order) => PublishAsync(new OrderIsInProgressEvent
	{
		OrderId = order.Id,
		Lines = null
	});
}