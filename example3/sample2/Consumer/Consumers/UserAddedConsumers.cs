using Consumer.Messages;
using MassTransit;

namespace Consumer.Consumers;

public class UserAddedConsumers : IConsumer<Messages.UserAdded>
{
    private readonly ILogger _logger;

    public UserAddedConsumers(ILogger<UserAddedConsumers> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<UserAdded> context)
    {
        _logger.LogInformation("[{timestamp}] UserAdded",
            DateTime.Now);
        return Task.CompletedTask;
    }
}