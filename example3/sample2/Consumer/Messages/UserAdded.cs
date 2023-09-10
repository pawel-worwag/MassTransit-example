using MassTransit;

namespace Consumer.Messages;

[MessageUrn("UserAdded")]
public record UserAdded();