using MassTransit;

namespace Consumer.Messages;

[MessageUrn("UserDisabled")]
public record UserDisabled();