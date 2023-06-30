using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using SimpleRebus.Models;

namespace SimpleRebus.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TestingController : ControllerBase
{
    private readonly IBus _bus;

    public TestingController(IBus bus)
    {
        _bus = bus;
    }
    //Publish a message
    [HttpPost("advanced/publish")]
    public async Task Publish([FromBody] Project project)
        => await _bus.Advanced.Topics.Publish("project", project);

    //Subscribe to a topic
    [HttpPost("advanced/subscribe")]
    public async Task Subscribe()
        => await _bus.Advanced.Topics.Subscribe("project");

    //Unsubscribe from a topic 
    [HttpPost("advanced/unsubscribe")]
    public async Task Unsubscribe() =>
        await _bus.Advanced.Topics.Unsubscribe("project");

    // BELOW DOES NOT WORK - Trying to figure out why

    //publish simple
    [HttpPost("publish")]
    public async Task PublishSimple([FromBody] MyEvent myEvent)
        => await _bus.Publish(myEvent);

    //subscrive simple
    [HttpPost("subscribe")]
    public async Task SubscribeSimple() 
        => await _bus.Subscribe<MyEvent>();

    //unsubscribe simple
    [HttpPost("unsubscribe")]
    public async Task UnsubscribeSimple()
        => await _bus.Unsubscribe<MyEvent>();
}
