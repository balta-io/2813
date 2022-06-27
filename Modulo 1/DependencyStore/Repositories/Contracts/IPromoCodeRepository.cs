using DependencyStore.Models;

namespace DependencyStore.Repositories.Contracts;

public interface IPromoCodeRepository
{
    Task<PromoCode?> GetPromoCodeAsync(string promoCode);
}