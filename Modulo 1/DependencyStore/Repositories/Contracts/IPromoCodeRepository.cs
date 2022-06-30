using DependencyStore.Models;

namespace DependencyStore.Repositories.Contracts;

public interface IPromoCodeRepository
{
    Guid Id { get; set; }
    Guid DatabaseConnectionId { get; set; }
    Task<PromoCode?> GetPromoCodeAsync(string promoCode);
}