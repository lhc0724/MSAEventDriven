using Shared.Models;

namespace Shared.Meta;

public interface IEventDispatcher<TEvent> where TEvent : Event
{
    void Publish(TEvent @event);
    Task PublishAsync(TEvent @event);
    Task PublishManyAsync(ICollection<TEvent> @events);
}