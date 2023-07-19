using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using Rebus.ServiceProvider;
using SimpleRebus.Models;

namespace SimpleRebus.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TestingController : ControllerBase
{
    private readonly IBus _bus;
    private readonly IBusRegistry _busses;

    public TestingController(IBus bus, IBusRegistry busses)
    {
        _bus = bus;
        _busses = busses;
        var x = busses.GetBus("SecondaryBus");
    }
    //Publish a message
    [HttpPost("advanced/publish")]
    public async Task Publish([FromBody] MyEvent myEvent)
        => await _bus.Advanced.Topics.Publish("myeventthing", myEvent);

    //Subscribe to a topic
    [HttpPost("advanced/subscribe")]
    public async Task Subscribe()
        => await _bus.Advanced.Topics.Subscribe("myeventthing");

    //Unsubscribe from a topic 
    [HttpPost("advanced/unsubscribe")]
    public async Task Unsubscribe() =>
        await _bus.Advanced.Topics.Unsubscribe("myeventthing");

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
