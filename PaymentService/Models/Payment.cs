using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentService.Models;

public class Payment
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }
	public long OrderId { get; set; }
	public decimal Amount { get; set; }
	public DateTime Date { get; set; }
	public string Status { get; set; }
}