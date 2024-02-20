namespace Shared.Models;

public abstract class Event
{
    public Guid Id { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string Jwt { get; set; } //Bearer Authentication token

    public Event()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    public Event(Guid id, DateTime creationDate)
    {
        Id = id;
        CreationDate = creationDate;
    }
}