using Shared.Models;

namespace Shared.Messages;

public class OrderIsInProgressEvent : Event
{
	public long OrderId { get; set; }
	public ICollection<OrderIsInProgressEventLine> Lines { get; set; }
}

public class OrderIsInProgressEventLine
{
	public long Product_Id { get; set; }
	public int Quantity { get; set; }
}