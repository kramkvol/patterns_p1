using System;

namespace Ciphers.Core
{
    public static class UtilForTables
    {
        public static char[,] BuildTable(string cleanKey, int rows, int cols)
        {
            char[,] table = new char[rows, cols];

            for (int i = 0; i < cleanKey.Length; i++)
            {
                table[i / cols, i % cols] = cleanKey[i];
            }

            return table;
        }

        public static char[,] BuildVigenereTable(string abc, int size)
        {
            char[,] table = new char[size, size];

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    table[r, c] = abc[(c + r) % size];
                }
            }

            return table;
        }

        public static (int row, int col) FindPosition(char[,] table, char c)
        {
            for (int r = 0; r < table.GetLength(0); r++)
                for (int col = 0; col < table.GetLength(1); col++)
                    if (table[r, col] == c)
                        return (r, col);
            throw new Exception($"Character {c} not found.");
        }
    }
}
