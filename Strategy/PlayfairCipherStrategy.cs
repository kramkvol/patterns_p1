using System;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace CiphersWithPatterns
{
    public class PlayfairCipherStrategy : ICipherStrategy
    {
        private string type { get; }
        private string abc { get; }
        private int rows { get; }
        private int cols { get; }
        private string message { get; }
        private string key1 { get; }
        private string cleanKey1 { get; }
        private char[,] table1 { get; }
        private string bigrams { get; }
        public PlayfairCipherStrategy(string abc, int row, int col, string message, string key1)
        {
            this.abc = abc;
            this.rows = row;
            this.cols = col;
            this.message = message.ToLower().Replace("j", "i");
            this.key1 = key1;

            cleanKey1 = CipherTextPreprocessor.GetUniqLettersReplace(key1 + abc, abc);
            table1 = CipherTableBuilder.BuildTable(cleanKey1, row, col);
            bigrams = CipherTextPreprocessor.GetBigramText(message, abc);
        }

        public string Encrypt()
        {
            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < bigrams.Length; i += 2)
                encrypted.Append(EncryptBigram(bigrams[i], bigrams[i + 1]));

            return encrypted.ToString();
        }

        public string Decrypt()
        {
            string encrypted = CipherTextPreprocessor.GetOnlyLetters(message).ToLower();
            StringBuilder restored = new StringBuilder();

            for (int i = 0; i < encrypted.Length; i += 2)
                restored.Append(DecryptBigram(encrypted[i], encrypted[i + 1]));

            return restored.ToString();
        }

        public string CleanDecrypt()
        {
            string decrypt = CipherTextPreprocessor.GetOnlyLetters(message);
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

        public string getType()
        {
            return type;
        }
        public string getMessege()
        {
            return message;
        }
        public string getAbc()
        {
            return abc;
        }
        public int getRow()
        {
            return rows;
        }
        public int getCol()
        {
            return cols;
        }
        public string getKey1()
        {
            return key1;
        }
        public string getKey2()
        {
            return null;
        }
        public string getCleanKey1()
        {
            return cleanKey1;
        }
        public string getCleanKey2()
        {
            return null;
        }
        public string getBigramms()
        {
            return bigrams;
        }
        public char[,] getTable1()
        {
            return table1;
        }
        public char[,] getTable2()
        {
            return null;
        }

    }
}
