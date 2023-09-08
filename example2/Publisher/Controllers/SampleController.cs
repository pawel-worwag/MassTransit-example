using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers;

[ApiController]
[Route("samples")]
public class SampleController : ControllerBase
{
    private readonly IBus _bus;
    private readonly ILogger _logger;

    public SampleController(IBus bus, ILogger<SampleController> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    [HttpGet("send")]
    public async Task<IActionResult> Send()
    {
        var sendEndpoint = await _bus.GetPublishSendEndpoint<Messages.SendMail>();
        var message = new Messages.SendMail()
        {
            Subject = "new user",
            Recipients = new List<string>() { "user@example.com" },
            Body = "Hello new user."
        };
        await sendEndpoint.Send<Messages.SendMail>(message);
        
        _logger.LogInformation("SendMail - subject:{subject}, recipients:{recipients}, body:{body}",
            message.Subject,
            string.Join(",",message.Recipients),
            message.Body);
        return Ok();
    }
    
    [HttpGet("publish")]
    public async Task<IActionResult> Publish()
    {
        var message = new Messages.UserAdded()
        {
            Email = "user@example.com",
            Guid = Guid.NewGuid()
        };
        await _bus.Publish<Messages.UserAdded>(message);
        _logger.LogInformation("UserAdded - guid:{guid}, email:{email}",message.Guid.ToString(),message.Email);
        return Ok();
    }
}