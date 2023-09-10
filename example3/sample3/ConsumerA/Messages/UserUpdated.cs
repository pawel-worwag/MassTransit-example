using MassTransit;

namespace ConsumerA.Messages;

[MessageUrn("UserUpdated")]
public record UserUpdated();