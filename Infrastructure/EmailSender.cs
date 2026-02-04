namespace LegacyShop.Infrastructure;

public class EmailSender: ISender
{
    public void Send(string to, string subject, string body)
    {
        Console.WriteLine($"[EMAIL] To: {to}");
        Console.WriteLine($"[EMAIL] Subject: {subject}");
        Console.WriteLine("[EMAIL] Body:");
        Console.WriteLine(body);
    }
}
