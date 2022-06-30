using DependencyStore.Models;

namespace DependencyStore.Repositories.Contracts;

public interface ICustomerRepository
{
    Guid Id { get; set; }
    Guid DatabaseConnectionId { get; set; }
    Task<Customer?> GetCustomerAsync(int id);
}