using Ciphers.Singletone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.Core
{
    public static class UtilForDecorator
    {
        public static void PrintTable(ILogger logger, char[,] table, string key)
        {
            logger.LogCharpter($"Table for key '{key}':");
            string str = "";
            for (int r = 0; r < table.GetLength(0); r++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    str += (table[r, c] + " ");
                }
                logger.LogBaseLine(str);
                str = "";
            }
        }

        public static void PrintVigenereTable(ILogger logger, char[,] table)
        {
            logger.LogCharpter($"The Vigener's table:");
            string str = "";
            for (int r = 0; r < table.GetLength(0); r++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    if (r == 0 || c == 0)
                    {
                        str += (table[r, c] + " ").ToUpper();
                    }
                    else 
                    {
                        str += (table[r, c] + " ");
                    }
                }
                logger.LogBaseLine(str);
                str = "";
            }
        }

        public static string GetFormed(string message)
        {
            string result = "";
            for (int i = 0; i < message.Length - 1; i += 2)
            {
                result += ($"{message[i]} {message[i + 1]} | ");
            }
            return result;
        }
    }
}
