using Microsoft.Data.SqlClient;

namespace DependencyStore.Services;

public class Database
{
    private readonly SqlConnection _connection;
    public Guid Id { get; private set; }
    
    public Database(SqlConnection connection)
    {
        _connection = connection;
        Id = Guid.NewGuid();
    }
}