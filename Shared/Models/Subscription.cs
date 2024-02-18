namespace Shared.Models;

public class Subscription(Type handlerType)
{
    public Type HandlerType { get; private set; } = handlerType;
}