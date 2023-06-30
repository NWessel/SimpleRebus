namespace SimpleRebus.Services;

public interface IMySingletonService
{
    Task<List<string>> ListAsync();
}
