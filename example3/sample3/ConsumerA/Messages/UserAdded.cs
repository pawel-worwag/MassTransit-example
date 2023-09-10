using MassTransit;

namespace ConsumerA.Messages;

[MessageUrn("UserAdded")]
public record UserAdded();