using System;
using System.Text;
using CiphersWithPatterns.Core;

namespace CiphersWithPatterns
{
    public class PlayfairCipherStrategy : ICipherStrategy, ICipherMetadata
    {
        public string abc { get; }
        public int rows { get; }
        public int cols { get; }
        public string message { get; }
        public string key1 { get; }

        public string cleanKey1 { get; }
        public char[,] table1 { get; }
        public string bigrams { get; }

        public string key2 { get; } = null;
        public string cleanKey2 { get; } = null;
        public char[,] table2 { get; } = null;

        public PlayfairCipherStrategy(string abc, int rows, int cols, string message, string key1)
        {
            this.abc = abc;
            this.rows = rows;
            this.cols = cols;
            this.message = message.ToLower().Replace("j", "i");
            this.key1 = key1;

            cleanKey1 = CipherTextPreprocessor.GetUniqLettersReplace(key1 + abc, abc);
            table1 = CipherTableBuilder.BuildTable(cleanKey1, rows, cols);
            bigrams = CipherTextPreprocessor.GetBigramText(message, abc);
        }

        public string Encrypt()
        {
            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < bigrams.Length; i += 2)
                encrypted.Append(EncryptBigram(bigrams[i], bigrams[i + 1]));

            return encrypted.ToString();
        }

        public string Decrypt(string encrypt)
        {
            StringBuilder restored = new StringBuilder();

            for (int i = 0; i < encrypt.Length; i += 2)
                restored.Append(DecryptBigram(encrypt[i], encrypt[i + 1]));

            return restored.ToString();
        }

        public string CleanDecrypt(string decrypt)
        {
            return CipherTextPreprocessor.PostprocessDecrypted(decrypt);
        }

        private (int row, int col) FindPosition(char c)
        {
            for (int r = 0; r < rows; r++)
                for (int col = 0; col < cols; col++)
                    if (table1[r, col] == c)
                        return (r, col);

            throw new Exception($"Char '{c}' not found in table.");
        }

        private string EncryptBigram(char a, char b)
        {
            var (r1, c1) = FindPosition(a);
            var (r2, c2) = FindPosition(b);

            if (r1 == r2)
                return $"{table1[r1, (c1 + 1) % cols]}{table1[r2, (c2 + 1) % cols]}";
            else if (c1 == c2)
                return $"{table1[(r1 + 1) % rows, c1]}{table1[(r2 + 1) % rows, c2]}";
            else
                return $"{table1[r1, c2]}{table1[r2, c1]}";
        }

        private string DecryptBigram(char a, char b)
        {
            var (r1, c1) = FindPosition(a);
            var (r2, c2) = FindPosition(b);

            if (r1 == r2)
                return $"{table1[r1, (c1 + cols - 1) % cols]}{table1[r2, (c2 + cols - 1) % cols]}";
            else if (c1 == c2)
                return $"{table1[(r1 + rows - 1) % rows, c1]}{table1[(r2 + rows - 1) % rows, c2]}";
            else
                return $"{table1[r1, c2]}{table1[r2, c1]}";
        }
    }
}
