using System;

namespace CiphersWithPatterns.Core
{
    public class ConsoleLogger : ILogger
    {
        private static readonly ConsoleLogger _instance = new ConsoleLogger();

        public static ConsoleLogger Instance => _instance;

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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[CHARPTER] {message}");
            Console.ResetColor();
        }

        public void LogSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"[SUCCESS] {message}");
            Console.ResetColor();
        }

        public void LogDebug(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }
    }
}
