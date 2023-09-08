using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers;

[ApiController]
[Route("samples")]
public class SampleController : ControllerBase
{
    private readonly IBus _bus;

    public SampleController(IBus bus)
    {
        _bus = bus;
    }

    [HttpGet("send")]
    public async Task<IActionResult> Send()
    {
        var sendEndpoint = await _bus.GetPublishSendEndpoint<Messages.SendMail>();
        await sendEndpoint.Send<Messages.SendMail>(new()
        {
            Subject = "new user",
            Recipients = new List<string>(){"user@example.com"},
            Body = "Hello new user."
        });
        return Ok();
    }
    
    [HttpGet("publish")]
    public async Task<IActionResult> Publish()
    {
        await _bus.Publish<Messages.UserAdded>(new()
        {
            Email = "user@example.com",
            Guid = Guid.NewGuid()
        });
        return Ok();
    }
}