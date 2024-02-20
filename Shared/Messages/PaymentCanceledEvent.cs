using System;
using Shared.Models;

namespace Shared.Messages;

public class PaymentCanceledEvent : Event
{
    public long OrderId { get; set; }
    public long PaymentId { get; set; }
    public string Reason { get; set; }
}
