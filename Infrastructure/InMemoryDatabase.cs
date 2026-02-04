using LegacyShop.Models;

namespace LegacyShop.Infrastructure;

public class InMemoryDatabase
{
    private readonly Dictionary<string, Order> _orders = new();

    public void SaveOrder(Order order)
    {
        _orders[order.Id] = order;
        Console.WriteLine($"[DB] Saved order {order.Id}");
    }

    public Order? GetOrder(string id)
    {
        return _orders.TryGetValue(id, out var order) ? order : null;
    }
}
