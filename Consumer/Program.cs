using Consumer.Infrastructure;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<RabbitMqTransportOptions>()
    .Configure(options =>
    {
        options.Host = builder.Configuration.GetValue<string>("Rabbit:Host");
        options.Port = builder.Configuration.GetValue<ushort>("Rabbit:Port");
        options.VHost = builder.Configuration.GetValue<string>("Rabbit:VHost");
        options.User = builder.Configuration.GetValue<string>("Rabbit:User");
        options.Pass = builder.Configuration.GetValue<string>("Rabbit:Pass");
        options.UseSsl = builder.Configuration.GetValue<bool>("Rabbit:UseSsl");
    });

builder.Services.AddMassTransit(x =>
{
    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(prefix: "Dev", includeNamespace: false));

    x.AddConsumer<MessageConsumer>();
    
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ReceiveEndpoint("message-queue", e =>
        {
            e.ConfigureConsumer<MessageConsumer>(context);
        });
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();