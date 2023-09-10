using MassTransit;

namespace ConsumerB.Messages;

[MessageUrn("UserDisabled")]
public record UserDisabled();