using Rebus.Handlers;
using SimpleRebus.Models;
using SimpleRebus.Services;
using Task = System.Threading.Tasks.Task;

namespace SimpleRebus.Incoming;

public class ProjectHandler : IHandleMessages<Project>
{
    private readonly IMyService _myService;

    public ProjectHandler(IMyService myService)
    {
        _myService = myService;
    }

    public async Task Handle(Project message)
    {
        var list = await _myService.ListAsync();
        Console.WriteLine($"Project: {message.Name}");
    }
}
