using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers;

[ApiController]
[Route("samples")]
public class SampleController : ControllerBase
{
    [HttpGet]
    public IActionResult Sample1()
    {
        return Ok();
    }
}