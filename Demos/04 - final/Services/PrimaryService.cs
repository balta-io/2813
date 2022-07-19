namespace DependencyInjectionLifetimeSample.Services;

public class PrimaryService : IService
{
    public Guid Id { get; set; } = Guid.NewGuid();
}