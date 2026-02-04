using System.Text;
using LegacyShop.Models;

namespace LegacyShop.Services;

public class ReceiptFormatter
{
    public string Format(Order order)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Receipt for Order: {order.Id}");
        sb.AppendLine($"Customer: {order.Customer.Name} <{order.Customer.Email}>");
        sb.AppendLine(new string('-', 40));

        foreach (var item in order.Items)
        {
            sb.AppendLine($"{item.Name} x{item.Quantity} @ {item.UnitPrice:0.00} = {(item.UnitPrice * item.Quantity):0.00}");
        }

        sb.AppendLine(new string('-', 40));
        sb.AppendLine($"Subtotal: {order.Subtotal:0.00} {order.Currency}");
        sb.AppendLine($"Discount: -{order.Discount:0.00} {order.Currency}");
        sb.AppendLine($"Shipping: {order.ShippingCost:0.00} {order.Currency}");
        sb.AppendLine($"Tax: {order.Tax:0.00} {order.Currency}");
        sb.AppendLine($"TOTAL: {order.Total:0.00} {order.Currency}");

        return sb.ToString();
    }
}
