using MassTransit;
using Messages;

namespace Consumer.Consumers;

public class SendMailConsumer:IConsumer<Messages.SendMail>
{
    private readonly ILogger _logger;

    public SendMailConsumer(ILogger<SendMailConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<SendMail> context)
    {
        var message = context.Message;
        _logger.LogInformation("SendMail - subject:{subject}, recipients:{recipients}, body:{body}",
            message.Subject,
            string.Join(",",message.Recipients),
            message.Body);
        return Task.CompletedTask;
    }
}