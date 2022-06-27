using DependencyStore.Models;

namespace DependencyStore.Repositories.Contracts;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerAsync(int id);
}