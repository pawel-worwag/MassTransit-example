using MassTransit;

namespace Publisher.Messages;

[MessageUrn("UserAdded")]
public record UserAdded();