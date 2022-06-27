namespace DependencyStore.Services.Contracts;

public interface IDeliveryFeeService
{
    Task<decimal> GetDeliveryFeeAsync(string zipCode);
}