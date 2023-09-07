using MassTransit;

namespace Consumer.Consumers;

public class WriteLogConsumerDefinition:ConsumerDefinition<WriteLogConsumer>
{
    public WriteLogConsumerDefinition()
    {
        EndpointName = "write-log-endpoint";
    }
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<WriteLogConsumer> consumerConfigurator)
    {
        base.ConfigureConsumer(endpointConfigurator, consumerConfigurator);
    }
}