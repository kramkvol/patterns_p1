using System;

namespace CiphersWithPatterns
{
    public class ConsoleLogger : ILogger
    {
        private static readonly ConsoleLogger instance = new ConsoleLogger();

        public static ConsoleLogger Instance => instance;

        private ConsoleLogger() { }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[INFO] {message}");
            Console.ResetColor();
        }

        public void LogError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {error}");
            Console.ResetColor();
        }

        public void LogResult(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[RESULT] {message}");
            Console.ResetColor();
        }

        public void LogCharpter(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"[CHARPTER] {message}");
            Console.ResetColor();
        }

        public void LogSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[SUCCESS] {message}");
            Console.ResetColor();
        }

        public void LogDebug(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        public void LogRequirement(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[REQUIREMENT] {message}");
            Console.ResetColor();
        }

        public void LogBase(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(message);
            Console.ResetColor();
        }

        public void LogBaseLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
