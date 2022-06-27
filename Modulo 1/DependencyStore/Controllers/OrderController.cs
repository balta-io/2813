using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyStore.Controllers;

[ApiController]
public class OrderController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IPromoCodeRepository _promoCodeRepository;
    private readonly IDeliveryFeeService _deliveryFeeService;

    public OrderController(
        ICustomerRepository customerRepository,
        IPromoCodeRepository promoCodeRepository,
        IDeliveryFeeService deliveryFeeService)
    {
        _customerRepository = customerRepository;
        _promoCodeRepository = promoCodeRepository;
        _deliveryFeeService = deliveryFeeService;
    }
    
    [Route("v1/orders")]
    [HttpPost]
    public async Task<string> Place(
        int customerId,
        string zipCode,
        string promoCode,
        int[] products)
    {
        var customer = await _customerRepository.GetCustomerAsync(customerId);
        var deliveryFee = await _deliveryFeeService.GetDeliveryFeeAsync(zipCode);
        var cupon = await _promoCodeRepository.GetPromoCodeAsync(promoCode);
        var discount = cupon?.Value ?? 0M;
        var order = new Order(deliveryFee, discount, new List<Product>());
        return $"Pedido {order.Code} gerado com sucesso!";
    }
}