namespace SimpleRebus.Services;

public interface IMyTransientService
{
    Task<List<string>> ListAsync();
}
