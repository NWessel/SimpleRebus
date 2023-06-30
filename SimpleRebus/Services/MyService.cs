namespace SimpleRebus.Services;

public class MyService : IMyService
{
    public Task<List<string>> ListAsync()
    {
        return Task.FromResult(new List<string> { "one", "two", "three" });
    }
}
