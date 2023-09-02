using MassTransit;

namespace Consumer.Infrastructure.Messages;

[MessageUrn("message")]
public record Message
{
    public Guid Guid { get; init; }
}