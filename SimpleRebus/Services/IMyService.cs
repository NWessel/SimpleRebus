namespace SimpleRebus.Services;

public interface IMyService
{
    Task<List<string>> ListAsync();
}
