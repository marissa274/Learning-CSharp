namespace LegacyShop.Infrastructure;

public class FileLogger
{
    public void Info(string message)
    {
        Console.WriteLine($"[FILELOG] {DateTime.Now:HH:mm:ss} {message}");
    }

    public void Error(string message)
    {
        Console.WriteLine($"[FILELOG][ERROR] {DateTime.Now:HH:mm:ss} {message}");
    }
}
