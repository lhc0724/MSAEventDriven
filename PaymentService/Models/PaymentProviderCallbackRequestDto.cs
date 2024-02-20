namespace PaymentService.Models;

public class PaymentProviderCallbackRequestDto
{
  public long PaymentId { get; set; }
  public int OrderId { get; set; }
  public int Amount { get; set; }
  public bool Success { get; set; }
}