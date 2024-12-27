using System;
using System.IO;

public static class Logger
{
    private static readonly string LogFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs", "error_log.txt");

    // Hata mesajını log dosyasına yazan metod
    public static void LogError(string message)
    {
        if (!Directory.Exists(Path.GetDirectoryName(LogFilePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));
        }

        using (StreamWriter writer = new StreamWriter(LogFilePath, true))
        {
            writer.WriteLine($"[{DateTime.Now}] - {message}");
        }
    }
}
