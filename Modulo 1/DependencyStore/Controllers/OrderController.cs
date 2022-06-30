using DependencyStore.Models;
using DependencyStore.Repositories;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DependencyStore.Controllers;

[ApiController]
public class OrderController : ControllerBase
{
    private readonly ApiConfiguration _config;
    private readonly Database _database;
    private readonly ICustomerRepository _customerRepository;
    private readonly IDeliveryFeeService _deliveryFeeService;
    private readonly IPromoCodeRepository _promoCodeRepository;

    public OrderController(
        ApiConfiguration config,
        Database database,
        ICustomerRepository customerRepository,
        IDeliveryFeeService deliveryFeeService,
        IPromoCodeRepository promoCodeRepository)
    {
        _config = config;
        _database = database;
        _customerRepository = customerRepository;
        _deliveryFeeService = deliveryFeeService;
        _promoCodeRepository = promoCodeRepository;
    }

    [Route("/")]
    [HttpGet]
    public IActionResult TestDependencyInjection()
    {
        Console.WriteLine($"Configuration (Nunca muda): {_config.Id}");
        Console.WriteLine($"Database (Muda a cada requisição): {_database.Id}");
        Console.WriteLine($"Customer (Sempre muda): {_customerRepository.Id}");
        Console.WriteLine($"Delivery Fee: {_deliveryFeeService.Id}");
        Console.WriteLine($"Promo Code: {_promoCodeRepository.Id}");

        return Ok(new
        {
            Configuration = _config.Id,
            Database = _database.Id,
            CustomerRepository = new
            {
                Id = _customerRepository.Id,
                DatabaseId = _customerRepository.DatabaseConnectionId
            },
            DeliveryFee = _deliveryFeeService.Id,
            PromoCodeRepository = new
            {
                Id = _promoCodeRepository.Id,
                DatabaseId = _promoCodeRepository.DatabaseConnectionId
            },
        });
    }
}