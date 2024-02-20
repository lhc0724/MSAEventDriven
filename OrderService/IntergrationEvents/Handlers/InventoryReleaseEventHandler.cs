using Shared.Messages;
using Shared.Meta;

namespace OrderService.IntergrationEvents.Handlers;

public class InventoryReleaseEventHandler : IEventHandler<InventoryReleaseEvent>
{
	private readonly ILogger<InventoryReleaseEventHandler> _logger;
	private const string LOGGING_PREFIX = "[InventoryReleaseEventHandler:OrderService]";

	public InventoryReleaseEventHandler(
			ILogger<InventoryReleaseEventHandler> logger)
	{
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	public Task Handle(InventoryReleaseEvent @event)
	{
		try
		{
			_logger.LogInformation("{message}", $"이벤트 발생 - {DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss")}");

			// 주문 취소 처리 
			_logger.LogInformation("{message}", $"{@event.OrderId}번 주문 취소 완료");
		}
		catch (Exception e)
		{
      _logger.LogError("error - {meesage}", e.Message);
      _logger.LogError("stackTrace - {stack}", e.StackTrace);
		}

		return Task.CompletedTask;
	}
}