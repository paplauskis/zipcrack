namespace zipcrack.Helpers;

public static class ConsoleLogger
{
    public static void LogUsage()
    {
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------\n");
        Console.WriteLine("Usage:\n"
                          + "To execute dictionary attack: dotnet run --dict --<file path>\n"
                          + "To execute brute force attack: dotnet run --brute --min=<minimum password length> --max=<maximum password length> --<file path>\n");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------");
    }

    public static void LogPasswordFound(string password)
    {
        Console.WriteLine($"ZIP password found: {password}");
    }

    public static void LogPasswordNotFound()
    {
        Console.WriteLine("ZIP password not found");
    }
}