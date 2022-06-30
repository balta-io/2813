namespace DependencyStore.Services.Contracts;

public interface IDeliveryFeeService
{
    Guid Id { get; set; }
    Task<decimal> GetDeliveryFeeAsync(string zipCode);
}