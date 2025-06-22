using System;
using CiphersWithPatterns.Commands;
using CiphersWithPatterns.Core;

namespace CiphersWithPatterns
{
    class Program
    {
        static void Main(string[] args)
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
            Console.ReadKey();
        }
    }
}
