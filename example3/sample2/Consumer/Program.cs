using MassTransit;
using Consumers = Consumer.Consumers;

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
builder.Services.AddMassTransit(configure =>
{
    configure.AddConsumer<Consumers.UserAddedConsumer>();
    configure.AddConsumer<Consumers.UserUpdatedConsumer>();
    configure.AddConsumer<Consumers.UserDisabledConsumer>();
    configure.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();