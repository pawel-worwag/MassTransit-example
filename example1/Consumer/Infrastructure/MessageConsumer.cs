using Consumer.Infrastructure.Messages;
using MassTransit;

namespace Consumer.Infrastructure;

public class MessageConsumer : IConsumer<Message>
{
    private readonly ILogger _logger;

    public MessageConsumer(ILogger<MessageConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<Message> context)
    {
        var m = context.Message;
        _logger.LogInformation("Message {guid}",m.Guid);
        return Task.CompletedTask;
    }
}