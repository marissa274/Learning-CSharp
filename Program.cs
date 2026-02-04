using LegacyShop.Models;
using LegacyShop.Services;

namespace LegacyShop;

public static class Program
{
    public static void Main()
    {
        var order = new Order
        {
            Id = Guid.NewGuid().ToString(),
            Customer = new Customer { Email = "hugo@example.com", Name = "Hugo" },
            Currency = "CAD",
            CouponCode = "PROMO10",
            ShippingMethod = "express"
        };

        order.Items.Add(new OrderItem { Sku = "KB-001", Name = "Keyboard", UnitPrice = 79.99m, Quantity = 1 });
        order.Items.Add(new OrderItem { Sku = "MS-123", Name = "Mouse", UnitPrice = 29.99m, Quantity = 2 });

        var orderService = new OrderService();
        orderService.Process(order);

        Console.WriteLine();
        Console.WriteLine("Done. Check output above.");
    }
}
