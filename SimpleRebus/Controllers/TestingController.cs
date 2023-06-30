using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using SimpleRebus.Models;

namespace SimpleRebus.Controllers;
[ApiController]
[Route("[controller]")]
public class TestingController : ControllerBase
{
    private readonly IBus _bus;

    public TestingController(IBus bus)
    {
        _bus = bus;
    }

    [HttpPost(Name = "SendMessage")]
    public async System.Threading.Tasks.Task SendMessage([FromBody] Project project)
    {
        try
        {
            //Doesn't work
            await _bus.Publish(project);

            //works
            await _bus.Advanced.Topics.Publish("project", project);


            //Doesn't work
            await _bus.Subscribe<Project>();

            //works
            await _bus.Advanced.Topics.Subscribe("project");
        }
        catch (Exception e)
        {
        }
        
    }
}