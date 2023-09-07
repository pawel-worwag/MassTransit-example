using MassTransit;
using Publisher.Infrastructure.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Message<Message>(x =>
        {
            x.SetEntityName(builder.Configuration.GetValue<string>("Rabbit:MessageExchangeName","message-exchange")!);
        });
        cfg.Publish<Message>(x => { x.ExchangeType = "topic"; });

    });
});

var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();