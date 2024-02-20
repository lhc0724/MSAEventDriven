using Shared.Models;

namespace Shared.Messages;

public class InventoryReleaseEvent : Event
{
	public long OrderId { get; set; }
}
