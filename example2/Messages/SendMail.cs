namespace Messages;

public record SendMail
{
    public required string Subject { get; init; }
    public required List<string> Recipients { get; init; }
    public required string Body { get; init; }
}