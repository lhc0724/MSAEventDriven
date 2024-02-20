using InventoryService.IntergrationEvents.Events;
using Shared.Meta;
using Shared.Messages;

namespace InventoryService.IntergrationEvents.Handlers;

public class PaymentCanceledEventHandler : IEventHandler<PaymentCanceledEvent>
{
	private readonly InventoryReleaseEventDispatcher _inventoryReleaseEventDispatcher;
	private readonly ILogger<PaymentCanceledEvent> _logger;
	private const string LOGGING_PREFIX = "[PaymentCanceledEventHandler:InventoryService]";

	public PaymentCanceledEventHandler(
			InventoryReleaseEventDispatcher inventoryReleaseEventDispatcher,
			ILogger<PaymentCanceledEvent> logger)
	{
		_inventoryReleaseEventDispatcher = inventoryReleaseEventDispatcher ?? throw new ArgumentNullException(nameof(inventoryReleaseEventDispatcher));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	public async Task Handle(PaymentCanceledEvent @event)
	{
		try
		{
      _logger.LogInformation("{message}", $"이벤트 발생 - {DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss")}");
			_logger.LogInformation("결재 취소");

			// 재고 취소 처리 로직

			// 재고 취소 완료 후 이벤트 게시
			await _inventoryReleaseEventDispatcher.DispatchAsync(@event.OrderId);
			_logger.LogInformation("재고 취소 처리 완료");

		}
		catch (Exception e)
		{
      _logger.LogError("error - {meesage}", e.Message);
      _logger.LogError("stackTrace - {stack}", e.StackTrace);
		}

		return;
	}
}
