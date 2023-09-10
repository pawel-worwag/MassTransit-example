using MassTransit;
using Messages;

namespace Consumer.Consumers;

public class UserUpdatedConsumer : IConsumer<Messages.UserUpdated>
{
    private readonly ILogger _logger;

    public UserUpdatedConsumer(ILogger<UserUpdatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<UserUpdated> context)
    {
        _logger.LogInformation("[{timestamp}] UserUpdated:",
            DateTime.Now);
        return Task.CompletedTask;
    }
}