using Consumer.Messages;
using MassTransit;

namespace Consumer.Consumers;

public class UserDisabledConsumers : IConsumer<Messages.UserDisabled>
{
    private readonly ILogger _logger;

    public UserDisabledConsumers(ILogger<UserDisabledConsumers> logger)
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