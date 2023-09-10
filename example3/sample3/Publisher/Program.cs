using MassTransit;
using Messages = Publisher.Messages;

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
builder.Services.AddMassTransit(configuration =>
{
    configuration.UsingRabbitMq((context, cfg) =>
    {
        cfg.Message<Messages.UserAdded>(c => { c.SetEntityName("UserAdded"); });
        cfg.Message<Messages.UserUpdated>(c => { c.SetEntityName("UserUpdated"); });
        cfg.Message<Messages.UserDisabled>(c => { c.SetEntityName("UserDisabled"); });
    });
});

var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();