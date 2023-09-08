using Consumer.Consumers;
using MassTransit;
using Messages;

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
var instanceId = "-"+Guid.NewGuid().ToString();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<SendMailConsumer>();
    x.AddConsumer<UserAddedConsumer>().Endpoint(c =>
    {
        c.InstanceId = instanceId;
        c.Temporary = true;
    });;
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();