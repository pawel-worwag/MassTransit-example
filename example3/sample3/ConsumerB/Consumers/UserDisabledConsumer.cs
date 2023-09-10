using ConsumerB.Messages;
using MassTransit;

namespace ConsumerB.Consumers;

public class UserDisabledConsumer : IConsumer<Messages.UserDisabled>
{
    private readonly ILogger _logger;

    public UserDisabledConsumer(ILogger<UserDisabledConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<UserDisabled> context)
    {
        _logger.LogInformation("[{timestamp}] UserDisabled",
            DateTime.Now);
        return Task.CompletedTask;
    }
}