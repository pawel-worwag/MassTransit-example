using MassTransit;

namespace Publisher.Messages;

[MessageUrn("UserDisabled")]
public record UserDisabled();