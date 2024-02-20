using Shared.Meta;
using OrderService.IntergrationEvents.Events;
using OrderService.Models;
using Shared.Messages;

namespace OrderService.IntergrationEvents.EventHandlers;

public class PaymentCompletedEventHandler : IEventHandler<PaymentCompletedEvent>
{
	private readonly OrderIsInProgressEventDispatcher _orderIsInProgressEventDispatcher;
	private readonly ILogger<PaymentCompletedEventHandler> _logger;
	private const string LOGGING_PREFIX = "[PaymentCompletedHandler:OrderService]";

	public PaymentCompletedEventHandler(
			OrderIsInProgressEventDispatcher orderIsInProgressEventDispatcher,
			ILogger<PaymentCompletedEventHandler> logger)
	{
		_orderIsInProgressEventDispatcher = orderIsInProgressEventDispatcher ?? throw new ArgumentNullException(nameof(orderIsInProgressEventDispatcher));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}

	// 결재 완료 구독
	public async Task Handle(PaymentCompletedEvent @event)
	{
		try
		{
			_logger.LogInformation($"이벤트 발생 - {DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss")}");

			_logger.LogInformation($"{@event.OrderId}번 주문 접수 완료");
			await _orderIsInProgressEventDispatcher.DispatchAsync(new Order
			{
				Id = @event.OrderId,
				Status = "Delivered"
			});

			_logger.LogInformation($"주문 접수 완료 이벤트 게시");
		}
		catch (Exception e)
		{
      _logger.LogError("error - {meesage}", e.Message);
      _logger.LogError("stackTrace - {stack}", e.StackTrace);
		}

		return;
	}
}