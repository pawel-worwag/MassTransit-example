using MassTransit;
using Consumers = ConsumerB.Consumers;
using Messages = ConsumerB.Messages;

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
    configure.AddConsumer<Consumers.UserAddedConsumer>().Endpoint(cfg =>
    {
        cfg.InstanceId = "-ConsumerB";
        cfg.Temporary = true;
    });
    configure.AddConsumer<Consumers.UserUpdatedConsumer>().Endpoint(cfg =>
    {
        cfg.InstanceId = "-ConsumerB";
        cfg.Temporary = true;
    });;
    configure.AddConsumer<Consumers.UserDisabledConsumer>().Endpoint(cfg =>
    {
        cfg.InstanceId = "-ConsumerB";
        cfg.Temporary = true;
    });;
    configure.UsingRabbitMq((context, cfg) =>
    {
        cfg.Message<Messages.UserAdded>(x =>
        {
            x.SetEntityName("UserAdded");
        });
        cfg.Message<Messages.UserUpdated>(x =>
        {
            x.SetEntityName("UserUpdated");
        });
        cfg.Message<Messages.UserDisabled>(x =>
        {
            x.SetEntityName("UserDisabled");
        });
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();