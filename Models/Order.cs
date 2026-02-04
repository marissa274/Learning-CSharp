namespace LegacyShop.Models;

public class Order
{
    public string Id { get; set; } = "";
    public Customer Customer { get; set; } = new();
    public List<OrderItem> Items { get; } = new();

    public string Currency { get; set; } = "CAD";        
    public string ShippingMethod { get; set; } = "standard";
    public string CouponCode { get; set; } = "";      

    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
}
