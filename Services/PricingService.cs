using LegacyShop.Models;

namespace LegacyShop.Services;

public class PricingService
{
    public decimal ComputeSubtotal(Order order)
    {
        decimal subtotal = 0m;
        foreach (var item in order.Items)
        {
            subtotal += item.UnitPrice * item.Quantity;
        }
        return subtotal;
    }

    public decimal ComputeDiscount(Order order)
    {
        if (order.CouponCode == "PROMO10")
            return order.Subtotal * 0.10m;

        if (order.CouponCode == "PROMO5")
            return 5m;

        return 0m;
    }

    public decimal ComputeShipping(Order order)
    {
        if (order.ShippingMethod == "express")
            return 15m;

        return 5m;
    }

    public decimal ComputeTax(Order order)
    {
        if (order.Currency == "CAD")
            return (order.Subtotal - order.Discount + order.ShippingCost) * 0.14975m; // genre QC-ish

        return (order.Subtotal - order.Discount + order.ShippingCost) * 0.10m;
    }
}
