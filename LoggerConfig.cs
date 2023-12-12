using System.IO;
using NLog;

public static class LoggerConfig
{
    private static Logger logger;
    public static void ConfigureLogger()
    {
        string path = Directory.GetCurrentDirectory() + "\\nlog.config";

        // Create instance of Logger
        logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
    }

    public static void LogDebug(string message)
    {
        logger.Debug(message);
    }
}

