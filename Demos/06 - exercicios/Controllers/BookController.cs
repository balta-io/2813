using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RestSharp;

namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        // Recupera o usuário
        await using var connection = new SqlConnection();
        var customer = await connection
            .QueryFirstOrDefaultAsync<Customer?>("SELECT * FROM [Customer] WHERE [Email]=@email",
                new { command.Email });

        if (customer == null)
            return NotFound();

        // Verifica se a sala está disponível
        var room = await connection.QueryFirstOrDefaultAsync<Book?>(
            "SELECT * FROM [Book] WHERE [Room]=@room AND [Date] BETWEEN @dateStart AND @dateEnd",
            new
            {
                Room = command.RoomId,
                DateStart = command.Day.Date,
                DateEnd = command.Day.Date.AddDays(1).AddTicks(-1),
            });

        // Se existe uma reserva, a sala está indisponível
        if (room is not null)
            return BadRequest();

        // Tenta fazer um pagamento
        var client = new RestClient("https://payments.com");
        var request = new RestRequest()
            .AddQueryParameter("api_key", "c20c8acb-bd76-4597-ac89-10fd955ac60d")
            .AddJsonBody(new
            {
                User = command.Email,
                CreditCard = command.CreditCard
            });
        var response = await client.PostAsync<PaymentResponse>(request, new CancellationToken());

        // Se a requisição não pode ser completa
        if (response is null)
            return BadRequest();

        // Se o status foi diferente de "pago"
        if (response?.Status != "paid")
            return BadRequest();

        // Cria a reserva
        var book = new Book(command.Email, command.RoomId, command.Day);

        // Salva os dados
        await connection.ExecuteAsync("INSERT INTO [Book] VALUES(@date, @email, @room)", new
        {
            book.Date,
            book.Email,
            book.Room
        });

        // Retorna o número da reserva
        return Ok();
    }
}

public class BookRoomCommand
{
    public string Email { get; set; }
    public Guid RoomId { get; set; }
    public DateTime Day { get; set; }
    public CreditCard CreditCard { get; set; }
}

public record PaymentResponse(int Code, string Status);

public record Customer(string Email);

public record Room(Guid Id, string Name);

public record Book(string Email, Guid Room, DateTime Date);

public record CreditCard(string Number, string Holder, string Expiration, string Cvv);