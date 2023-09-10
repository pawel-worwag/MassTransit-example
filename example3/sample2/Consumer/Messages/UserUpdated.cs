using MassTransit;

namespace Consumer.Messages;

[MessageUrn("UserUpdated")]
public record UserUpdated();