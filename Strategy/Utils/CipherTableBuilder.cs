namespace CiphersWithPatterns
{
    public static class CipherTableBuilder
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

    }
}
