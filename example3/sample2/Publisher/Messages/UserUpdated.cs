using MassTransit;

namespace Publisher.Messages;

[MessageUrn("UserUpdated")]
public record UserUpdated();