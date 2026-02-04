namespace LegacyShop.Models;

public class OrderItem
{
    public string Sku { get; set; } = "";
    public string Name { get; set; } = "";
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
