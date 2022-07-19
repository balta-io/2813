namespace DependencyInjectionLifetimeSample.Services;

public class TertiaryService
{
    private readonly PrimaryService _primaryService;
    private readonly SecondaryService _secondaryService;
    private readonly SecondaryService _secondaryServiceNewInstance;

    public TertiaryService(
        PrimaryService primaryService,
        SecondaryService secondaryService,
        SecondaryService secondaryServiceNewInstance)
    {
        _primaryService = primaryService;
        _secondaryService = secondaryService;
        _secondaryServiceNewInstance = secondaryServiceNewInstance;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PrimaryServiceId => _primaryService.Id;
    public Guid SecondaryServiceId => _secondaryService.Id;
    public Guid SecondaryServiceNewInstanceId => _secondaryServiceNewInstance.Id;
}