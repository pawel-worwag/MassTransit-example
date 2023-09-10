using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers;

[ApiController]
public class SampleController : ControllerBase
{
    private readonly IBus _bus;
    private readonly ILogger _logger;

    public SampleController(IBus bus, ILogger<SampleController> logger)
    {
        _bus = bus;
        _logger = logger;
    }
    
    [HttpGet("/s1")]
    public async Task<IActionResult> S1()
    {
        await _bus.Publish<Messages.UserAdded>(new Messages.UserAdded());
        _logger.LogInformation("[{timestamp}] UserAdded",
            DateTime.Now);
        return Ok();
    }    
    [HttpGet("/s2")]
    public async Task<IActionResult> S2()
    {
        await _bus.Publish<Messages.UserAdded>(new Messages.UserUpdated());
        _logger.LogInformation("[{timestamp}] UserAdded",
            DateTime.Now);
        return Ok();
    }    
    [HttpGet("/s3")]
    public async Task<IActionResult> S3()
    {
        await _bus.Publish<Messages.UserAdded>(new Messages.UserDisabled());
        _logger.LogInformation("[{timestamp}] UserAdded",
            DateTime.Now);
        return Ok();
    }
}