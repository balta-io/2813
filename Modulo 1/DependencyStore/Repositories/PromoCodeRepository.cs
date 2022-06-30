using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories;

public class PromoCodeRepository : IPromoCodeRepository
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DatabaseConnectionId { get; set; } = Guid.NewGuid();
    private readonly SqlConnection _connection;

    public PromoCodeRepository(SqlConnection connection, Database db)
    {
        _connection = connection;
        DatabaseConnectionId = db.Id;
    }

    public async Task<PromoCode?> GetPromoCodeAsync(string promoCode)
    {
        // var query = $"SELECT * FROM PROMO_CODES WHERE CODE={promoCode}";
        // return await _connection.QueryFirstOrDefaultAsync<PromoCode>(query);
        return null;
    }
}