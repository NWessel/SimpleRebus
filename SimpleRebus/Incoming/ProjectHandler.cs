using Rebus.Handlers;
using SimpleRebus.Models;
using Task = System.Threading.Tasks.Task;

namespace SimpleRebus.Incoming;

public class ProjectHandler : IHandleMessages<Project>
{
    public async Task Handle(Project message)
    {
        Console.WriteLine($"Project: {message.Name}");
    }
}
