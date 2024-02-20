using Shared.Meta;
using Shared.Messages;

namespace InventoryService.IntergrationEvents.Handlers;

public class OrderIsInProgressEventHandler : IEventHandler<OrderIsInProgressEvent>
{
  private readonly ILogger<OrderIsInProgressEventHandler> _logger;
  private const string LOGGING_PREFIX = "[OrderIsInProgressHandler:InventoryService]";

  public OrderIsInProgressEventHandler(
      ILogger<OrderIsInProgressEventHandler> logger)
  {
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }

  public Task Handle(OrderIsInProgressEvent @event)
  {
    try
    {
      _logger.LogInformation("{message}", $"이벤트 발생 - {DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss")}");

      // 재고 확보 로직
      _logger.LogInformation("재고 처리 완료");
    }
    catch (Exception e)
    {
      _logger.LogError("error - {meesage}", e.Message);
      _logger.LogError("stackTrace - {stack}", e.StackTrace);
    }
    return Task.CompletedTask;
  }
}