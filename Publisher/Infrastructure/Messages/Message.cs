using MassTransit;

namespace Publisher.Infrastructure.Messages;

[MessageUrn("message")]
public record Message
{
    public Guid Guid { get; } = Guid.NewGuid();
}