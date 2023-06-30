using Rebus.Handlers;
using SimpleRebus.Models;

namespace SimpleRebus.Incoming;

public class MyEventHandler : IHandleMessages<MyEvent>
{
    public async Task Handle(MyEvent message)
    {
        Console.WriteLine($"MyEvent: {message}");
    }
}
