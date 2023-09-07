using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Publisher.Infrastructure.Messages;

namespace Publisher.Controllers;

[ApiController]
[Route("/messages")]
public class MessageController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IPublishEndpoint _endpoints;

    public MessageController(IPublishEndpoint endpoints, ILogger<MessageController> logger)
    {
        _endpoints = endpoints;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult SendEMessage()
    {
        var message = new Message();
        _logger.LogInformation("Sending message {guid}",message.Guid);
        _endpoints.Publish<Message>(message);
        return Ok();
    }
}