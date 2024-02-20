using Shared.AzureServiceBus;
using Shared.Settings;
using Microsoft.Extensions.Options;
using Shared.Messages;

namespace InventoryService.IntergrationEvents.Events;

public class InventoryReleaseEventDispatcher : ServiceBusEventDispatcher<InventoryReleaseEvent>
{
	public InventoryReleaseEventDispatcher(IOptions<ServiceBusSettings> serviceBusOptions) : base(serviceBusOptions)
	{
	}

	// 재고 취소 처리 완료 후 이벤트 게시
	public Task DispatchAsync(long orderId) => PublishAsync(new InventoryReleaseEvent
	{
		OrderId = orderId
	});
}
