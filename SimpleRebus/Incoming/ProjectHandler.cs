using Rebus.Handlers;
using SimpleRebus.Models;
using SimpleRebus.Services;

namespace SimpleRebus.Incoming;

public class ProjectHandler : IHandleMessages<Project>
{
    private readonly IMyTransientService _myTransientService;
    private readonly IMyScopedService _myScopedService;
    private readonly IMySingletonService _mySingletonService;

    public ProjectHandler(IMyTransientService myTransientService, IMyScopedService myScopedService, IMySingletonService mySingletonService)
    {
        _myTransientService = myTransientService;
        _myScopedService = myScopedService;
        _mySingletonService = mySingletonService;
    }

    public async Task Handle(Project message)
    {
        var listFromTransient = await _myTransientService.ListAsync();
        var listFromScoped = await _myScopedService.ListAsync();
        var listFromSingleton = await _mySingletonService.ListAsync();
        Console.WriteLine($"Project: {message.Name}");
    }
}
