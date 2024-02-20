using Microsoft.AspNetCore.Mvc;
using PaymentService.IntergrationEvents.Events;
using PaymentService.Models;

namespace PaymentService.Controllers;

[ApiController]
[Route("/api/payments")]
public class PaymentController : ControllerBase
{
	private readonly PaymentCompletedEventDispatcher _paymentCompletedEventDispatcher;
	private readonly PaymentCanceledEventDispatcher _paymentCanceledEventDispatcher;

	public PaymentController(
			PaymentCompletedEventDispatcher paymentCompletedEventDispatcher,
			PaymentCanceledEventDispatcher paymentCanceledEventDispatcher)
	{
		_paymentCompletedEventDispatcher = paymentCompletedEventDispatcher ?? throw new ArgumentNullException(nameof(paymentCompletedEventDispatcher));
		_paymentCanceledEventDispatcher = paymentCanceledEventDispatcher ?? throw new ArgumentNullException(nameof(paymentCanceledEventDispatcher));
	}

	[HttpPost]
	public async Task<IActionResult> AddPayment([FromBody] PaymentProviderCallbackRequestDto request)
	{
		await _paymentCompletedEventDispatcher.DispatchAsync(new Payment()
		{
			OrderId = request.OrderId,
			Amount = request.Amount,
			Id = request.PaymentId,
			Status = "Completed"
		});

		Console.WriteLine($"결제 아이디 {request.PaymentId}번 결제 완료 처리");

		return Ok();
	}

	[HttpPost("cancel")]
	public async Task<IActionResult> CancelPayment([FromBody] PaymentProviderCallbackRequestDto request)
	{
		await _paymentCanceledEventDispatcher.DispatchAsync(new Payment()
		{
			OrderId = request.OrderId,
			Id = request.PaymentId,
			Status = "Cancel"
		});

		Console.WriteLine($"{request.PaymentId}번 결제 취소");

		return Ok();
	}
}