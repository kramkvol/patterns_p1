using CiphersWithPatterns;
using System;
using ThePlayfairCipher.Bridge.Abstractions;

namespace ThePlayfairCipher.Bridge.Implementations
{
    public class ConsoleUIImpl : ICipherUIImpl
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput(string prompt)
        {
            Console.Write($"{prompt}: ");
            return Console.ReadLine();
        }

        public void ShowResult(string result)
        {
            Console.WriteLine($"\nResult: {result}");
        }

        public void Start()
        {
            string abc = "abcdefghijklmnopqrstuvwxyz";
            int rows = 5, cols = 5;
            string message = "hello world!";
            var logger = ConsoleLogger.Instance;

            var invoker = new CommandInvoker();
            invoker.AddCommand(new RunCipherCommand("Playfair", abc, rows, cols, message, "strong", null, logger));
            invoker.AddCommand(new RunCipherCommand("Winston", abc, rows, cols, message, "strong", "cipher", logger));
            invoker.AddCommand(new RunCipherCommand("Vigenere", abc, 0, 0, message, "key", null, logger));

            invoker.RunAll();
        }
    }
}

