using MassTransit;

namespace ConsumerB.Messages;

[MessageUrn("UserAdded")]
public record UserAdded();