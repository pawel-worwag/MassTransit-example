namespace Consumer.Infrastructure.Messages;

public record Message
{
    public Guid Guid { get; init; }
}