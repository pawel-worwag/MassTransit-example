namespace Messages;

public record UserAdded
{
    public required Guid Guid { get; init; }
    public required string Email { get; init; }
}