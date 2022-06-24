using System.Globalization;

class Program
{
    public static void Main()
    {
        ILogger logger = new ConsoleLogger(LogLevel.Trace);

        logger.Trace("I'm a Trace");
        logger.Log("I'm a Log");
        logger.Warn("I'm a Warning");
        logger.Error("I'm an Error");
    }
}

public class Time
{
    public string Iso8601Now ()
    {
        return DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture);
    }
}

public interface ILogger
{
    public LogLevel LogLevel { get; set; }
    
    public void Trace(string message);
    public void Log(string message);
    public void Warn(string message);
    public void Error(string message);
}

public class ConsoleLogger : ILogger
{
    public LogLevel LogLevel { get; private set; }

    private readonly Time time = new();

    public ConsoleLogger (LogLevel level)
    {
        LogLevel = level;
    }
    
    public void Trace(string message)
    {
        Console.WriteLine($"   Trace    {time.Iso8601Now()} {message}");
    }

    public void Log(string message)
    {
        Console.WriteLine($"   Log      {time.Iso8601Now()} {message}");
    }

    public void Warn(string message)
    {
        if(LogLevel >= LogLevel.Warn)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"!  Warning  {time.Iso8601Now()} {message}");
            Console.ForegroundColor = color;
        }
    }

    public void Error(string message)
    {
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"!! Error    {time.Iso8601Now()} {message}");
        Console.ForegroundColor = color;
    }
}

public enum LogLevel
{
    None,
    Error,
    Warn,
    Log,
    Trace
}