namespace LegacyShop.Infrastructure;

public interface ISender
{
    void Send(string to, string subject, string body);
}