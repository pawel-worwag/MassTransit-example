using Consumer.Messages;
using MassTransit;

namespace Consumer.Consumers;

public class UserUpdatedConsumers : IConsumer<Messages.UserUpdated>
{
    private readonly ILogger _logger;

    public UserUpdatedConsumers(ILogger<UserUpdatedConsumers> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<UserUpdated> context)
    {
        _logger.LogInformation("[{timestamp}] UserUpdated",
            DateTime.Now);
        return Task.CompletedTask;
    }
}