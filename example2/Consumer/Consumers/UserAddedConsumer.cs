using MassTransit;
using Messages;

namespace Consumer.Consumers;

public class UserAddedConsumer : IConsumer<Messages.UserAdded>
{
    public Task Consume(ConsumeContext<UserAdded> context)
    {
        throw new NotImplementedException();
    }
}