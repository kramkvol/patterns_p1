using System;
using System.Text;

namespace CiphersWithPatterns
{
    public static class CipherDebugger
    {
        public static string PrintInf(ICipherStrategy strategy)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Cipher Debug Info:");

            if (!string.IsNullOrWhiteSpace(strategy.abc))
                sb.AppendLine($"Alphabet: {strategy.abc}");
            if (strategy.rows > 0 && strategy.cols > 0)
                sb.AppendLine($"Table size: {strategy.rows} x {strategy.cols}");
            if (!string.IsNullOrWhiteSpace(strategy.message))
                sb.AppendLine($"Original Msg: {strategy.message}");
            if (!string.IsNullOrWhiteSpace(strategy.key1))
                sb.AppendLine($"Key 1: {strategy.key1}");
            if (!string.IsNullOrWhiteSpace(strategy.key2))
                sb.AppendLine($"Key 2: {strategy.key2}");
            if (!string.IsNullOrWhiteSpace(strategy.cleanKey1))
                sb.AppendLine($"Cleankey1: {strategy.cleanKey1}");
            if (!string.IsNullOrWhiteSpace(strategy.cleanKey2))
                sb.AppendLine($"Cleankey2: {strategy.cleanKey2}");

            if (!string.IsNullOrEmpty(strategy.bigrams))
            {
                sb.AppendLine($"Bigrams: {strategy.cleanKey2}");
                for (int i = 0, count = 0; i < strategy.bigrams.Length - 1; i += 2)
                {
                    sb.Append($"{strategy.bigrams[i]} {strategy.bigrams[i + 1]} | ");
                    if (++count % 8 == 0)
                        sb.AppendLine();
                }
            }
            if (strategy.table1 != null && strategy.key1 != null)
            {
                sb.AppendLine($"Table for key '{strategy.key1}':");
                for (int r = 0; r < strategy.table1.GetLength(0); r++)
                {
                    for (int c = 0; c < strategy.table1.GetLength(1); c++)
                    {
                        sb.Append(strategy.table1[r, c] + " ");
                    }
                    sb.AppendLine("");
                }
            }
            if (strategy.table2 != null && strategy.key2 != null)
            {
                sb.AppendLine($"Table for key '{strategy.key2}':");
                for (int r = 0; r < strategy.table2.GetLength(0); r++)
                {
                    for (int c = 0; c < strategy.table2.GetLength(1); c++)
                    {
                        sb.Append(strategy.table2[r, c] + " ");
                    }
                    sb.AppendLine("");
                }
            }

            return sb.ToString();
        }

    }
}
