namespace SimpleRebus.Services;

public class MyService : IMyTransientService, IMyScopedService, IMySingletonService
{
    public Task<List<string>> ListAsync()
    {
        return Task.FromResult(new List<string> { "one", "two", "three" });
    }
}
