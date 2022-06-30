using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DatabaseConnectionId { get; set; } = Guid.NewGuid();
    private readonly SqlConnection _connection;

    public CustomerRepository(
        SqlConnection connection,
        Database db)
    {
        _connection = connection;
        DatabaseConnectionId = db.Id;
    }

    public async Task<Customer?> GetCustomerAsync(int id)
    {
        // var query = $"SELECT * FROM CUSTOMER WHERE ID={id}"; 
        // return await _connection
        //     .QueryFirstAsync<Customer>(query);
        return null;
    }
}