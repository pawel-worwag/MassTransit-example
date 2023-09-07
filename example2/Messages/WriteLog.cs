namespace Messages;

public record WriteLog
{
    public DateTime TimeStamp { get;  } = DateTime.UtcNow;
    public required string Severity { get; init; }
    public required string Message { get; init; }
}