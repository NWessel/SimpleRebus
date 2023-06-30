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

    [HttpPost("advanced/publish")]
    public async System.Threading.Tasks.Task Publish([FromBody] Project project)
    {
        try
        {

            //works
            await _bus.Advanced.Topics.Publish("project", project);
        }
        catch (Exception e)
        {
            throw;
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
            throw;
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
            throw;
        }

    }

    //publish simple
    [HttpPost("publish")]
    public async System.Threading.Tasks.Task PublishSimple([FromBody] Project project)
    {
        try
        {
            //Doesnt work
            await _bus.Publish(project);
        }
        catch (Exception e)
        {
            throw;
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
            throw;
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
            throw;
        }

    }
}
