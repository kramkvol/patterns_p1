using System;
using CiphersWithPatterns.Core;

namespace CiphersWithPatterns
{
    public static class CipherDebugger
    {
        private static readonly ILogger logger = ConsoleLogger.Instance;

        public static void Print(ICipherStrategy strategy)
        {
            PrintInformation(strategy);
            if (strategy.bigrams!= null)
            {
                PrintBigrams(strategy);
            }
            if (strategy.table1 != null && strategy.key1 != null)
            {
                PrintTable(strategy.table1, strategy.key1);
            }
            if (strategy.table2 != null && strategy.key2 != null)
            {
                PrintTable(strategy.table2, strategy.key2);
            }
        }

        private static void PrintInformation(ICipherStrategy strategy)
        {
            logger.LogCharpter("Cipher Debug Info:");
            if (!string.IsNullOrWhiteSpace(strategy.abc))
                logger.LogDebug($"Alphabet      : {strategy.abc}");
            if (strategy.rows > 0 && strategy.cols > 0)
                logger.LogDebug($"Table size    : {strategy.rows} x {strategy.cols}");
            if (!string.IsNullOrWhiteSpace(strategy.message))
                logger.LogDebug($"Original Msg  : {strategy.message}");
            if (!string.IsNullOrWhiteSpace(strategy.key1))
                logger.LogDebug($"Key 1         : {strategy.key1}");
            if (!string.IsNullOrWhiteSpace(strategy.key2))
                logger.LogDebug($"Key 2         : {strategy.key2}");
            if (!string.IsNullOrWhiteSpace(strategy.cleanKey1))
                logger.LogDebug($"Cleankey1     : {strategy.cleanKey1}");
            if (!string.IsNullOrWhiteSpace(strategy.cleanKey2))
                logger.LogDebug($"Cleankey2     : {strategy.cleanKey2}");
        }

        private static void PrintBigrams(ICipherStrategy strategy)
        {
            logger.LogCharpter("Bigrams:");
            for (int i = 0, count = 0; i < strategy.bigrams.Length - 1; i += 2)
            {
                Console.Write($"{strategy.bigrams[i]} {strategy.bigrams[i + 1]} | ");
                if (++count % 8 == 0) Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void PrintTable(char[,] table, string key)
        {
            logger.LogCharpter($"Table for key '{key}':");
            for (int r = 0; r < table.GetLength(0); r++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    Console.Write(table[r, c] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
