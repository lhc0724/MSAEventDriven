using Shared.Models;

namespace Shared.Messages
{
    public class PaymentCompletedEvent : Event
    {
        public long OrderId { get; set; }
        public long PaymentId { get; set; }
    }
}