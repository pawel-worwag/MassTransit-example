using MassTransit;

namespace ConsumerB.Messages;

[MessageUrn("UserUpdated")]
public record UserUpdated();