namespace DependencyStore.Models;

public class Order
{
    public string Code { get; set; }
    public DateTime Date { get; set; }
    public decimal DeliveryFee { get; set; }
    public decimal Discount { get; set; }
    public int[] Products { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
}