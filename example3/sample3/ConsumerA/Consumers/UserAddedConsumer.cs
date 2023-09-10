using ConsumerA.Messages;
using MassTransit;

namespace ConsumerA.Consumers;

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