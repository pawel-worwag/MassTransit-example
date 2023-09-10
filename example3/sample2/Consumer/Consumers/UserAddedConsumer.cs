using Consumer.Messages;
using MassTransit;

namespace Consumer.Consumers;

public class UserAddedConsumer : IConsumer<Messages.UserAdded>
{
    private readonly ILogger _logger;

    public UserAddedConsumer(ILogger<UserAddedConsumer> logger)
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