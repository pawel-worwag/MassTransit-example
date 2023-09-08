using MassTransit;
using Messages;

namespace Consumer.Consumers;

public class SendMailConsumer:IConsumer<Messages.SendMail>
{
    public Task Consume(ConsumeContext<SendMail> context)
    {
        throw new NotImplementedException();
    }
}