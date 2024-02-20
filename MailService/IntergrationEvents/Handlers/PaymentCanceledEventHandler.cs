using Shared.Messages;
using Shared.Meta;

namespace MailService.IntergrationEvents.Handlers;

public class PaymentCanceledEventHandler : IEventHandler<PaymentCanceledEvent>
{
  private readonly ILogger<PaymentCanceledEvent> _logger;
  private const string LOGGING_PREFIX = "[PaymentCanceledEventHandler:MailService]";

  public PaymentCanceledEventHandler(
      ILogger<PaymentCanceledEvent> logger)
  {
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }

  public Task Handle(PaymentCanceledEvent @event)
  {
    try
    {
      _logger.LogInformation("{info}", $"이벤트 발생 - {DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss")}");
      _logger.LogInformation("payment-Id: {payment}, order-Id: {order}", @event.PaymentId, @event.OrderId);

      //sending payment cancel mail
      _logger.LogInformation("결재 취소 메일 보내기");
    }
    catch (Exception e)
    {
      _logger.LogError("error - {meesage}", e.Message);
      _logger.LogError("stackTrace - {stack}", e.StackTrace);
    }

    return Task.CompletedTask;
  }
}
