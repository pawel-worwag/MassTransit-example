using MassTransit;

namespace ConsumerA.Messages;

[MessageUrn("UserDisabled")]
public record UserDisabled();