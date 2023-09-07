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

    [HttpGet]
    public async Task<IActionResult> Sample1()
    {
        var uri = new Uri(_bus.Address,"write-log-exchange?type=topic");
        var endpoint = await _bus.GetSendEndpoint(uri);
        await endpoint.Send<Messages.WriteLog>(new() { Severity = "INFO", Message = "Test123" });
        return Ok();
    }
}