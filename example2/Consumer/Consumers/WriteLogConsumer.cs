using MassTransit;
using Messages;

namespace Consumer.Consumers;

public class WriteLogConsumer : IConsumer<Messages.WriteLog>
{
    private readonly ILogger _logger;

    public WriteLogConsumer(ILogger<WriteLogConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<WriteLog> context)
    {
        _logger.LogInformation("Incoming message");
        return Task.CompletedTask;
    }
}