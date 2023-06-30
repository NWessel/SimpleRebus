namespace SimpleRebus.Services;

public interface IMyScopedService
{
    Task<List<string>> ListAsync();
}
