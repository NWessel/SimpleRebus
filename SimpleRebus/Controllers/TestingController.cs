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

    [HttpPost("send")]
    public async System.Threading.Tasks.Task SendMessage([FromBody] Project project)
    {
        try
        {

            //works
            await _bus.Advanced.Topics.Publish("project", project);


            //await _bus.Advanced.Topics.Subscribe("project");
        }
        catch (Exception e)
        {
        }
        
    }

    //Subscribe to a topic
    [HttpPost("advanced/subscribe")]
    public async System.Threading.Tasks.Task Subscribe()
    {
        try
        {
            //works
            await _bus.Advanced.Topics.Subscribe("project");
        }
        catch (Exception e)
        {
        }

    }

    //Unsubscribe from a topic 
    [HttpPost("advanced/unsubscribe")]
    public async System.Threading.Tasks.Task Unsubscribe()
    {
        try
        {
            //works
            await _bus.Advanced.Topics.Unsubscribe("project");
        }
        catch (Exception e)
        {
        }

    }

    //subscrive simple
    [HttpPost("subscribe")]
    public async System.Threading.Tasks.Task SubscribeSimple()
    {
        try
        {
            //Doesnt work
            await _bus.Subscribe<Project>();
        }
        catch (Exception e)
        {
        }

    }

    //unsubscribe simple
    [HttpPost("unsubscribe")]
    public async System.Threading.Tasks.Task UnsubscribeSimple()
    {
        try
        {
            //Doesnt work
            await _bus.Unsubscribe<Project>();
        }
        catch (Exception e)
        {
        }

    }
}
