using Shared.Messages;
using Shared.Meta;

namespace MailService.IntergrationEvents.Handlers;

public class PaymentCompletedEventHandler : IEventHandler<PaymentCompletedEvent>
{
  private readonly ILogger<PaymentCompletedEventHandler> _logger;

  private const string LOGGING_PREFIX = "[PaymentCompletedHandler:MailService]";

  public PaymentCompletedEventHandler(
      ILogger<PaymentCompletedEventHandler> logger)
  {
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }

  // 결재 완료 구독
  public Task Handle(PaymentCompletedEvent @event)
  {
    try
    {
      _logger.LogInformation("{info}", $"이벤트 발생 - {DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss")}");
      _logger.LogInformation("payment-Id: {payment}, order-Id: {order}", @event.PaymentId, @event.OrderId);

      //sending payment complete mail
      _logger.LogInformation("결제 완료 메일 보내기");
    }
    catch (Exception e)
    {
      _logger.LogError("error - {meesage}", e.Message);
      _logger.LogError("stackTrace - {stack}", e.StackTrace);
    }

    return Task.CompletedTask;
  }
}