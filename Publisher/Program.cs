using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();