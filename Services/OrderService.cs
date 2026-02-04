using LegacyShop.Infrastructure;
using LegacyShop.Models;

namespace LegacyShop.Services;

public class OrderService
{
    private readonly FileLogger _logger = new();
    private readonly InMemoryDatabase _db = new();
    private readonly EmailSender _emailSender = new();

    private readonly PricingService _pricing = new();
    private readonly ReceiptFormatter _formatter = new();

    public void Process(Order order)
    {
        try
        {
            _logger.Info("Processing order...");

            if (order.Items.Count == 0)
            {
                _logger.Error("Order has no items.");
                throw new InvalidOperationException("Empty order.");
            }

            order.Subtotal = _pricing.ComputeSubtotal(order);
            order.Discount = _pricing.ComputeDiscount(order);
            order.ShippingCost = _pricing.ComputeShipping(order);
            order.Tax = _pricing.ComputeTax(order);

            order.Total = order.Subtotal - order.Discount + order.ShippingCost + order.Tax;

            _db.SaveOrder(order);

            var receipt = _formatter.Format(order);

            var subject = order.Total > 1000m
                ? "Your big order confirmation"
                : "Order confirmation";

            _emailSender.Send(order.Customer.Email, subject, receipt);

            _logger.Info($"Order processed successfully. Total={order.Total:0.00} {order.Currency}");
        }
        catch (Exception ex)
        {
            _logger.Error($"Processing failed: {ex.Message}");
            throw;
        }
    }
}
