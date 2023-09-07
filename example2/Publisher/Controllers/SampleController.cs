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
    public IActionResult Sample1()
    {
        _bus.Send<Messages.WriteLog>(new (){ Severity = "INFO", Message = "Test123"});
        
        return Ok();
    }
}