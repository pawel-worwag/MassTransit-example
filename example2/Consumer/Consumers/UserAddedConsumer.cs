using MassTransit;
using Messages;

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
        var message = context.Message;
        _logger.LogInformation("UserAdded - guid:{guid}, email:{email}",message.Guid.ToString(),message.Email);
        return Task.CompletedTask;
    }
}