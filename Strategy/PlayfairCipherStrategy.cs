using Ciphers.Core;
using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Ciphers.Strategy
{
    public class PlayfairCipherStrategy : BaseCipherStrategy   
    {
        protected string Abc { get; }
        protected string Message { get; }
        protected string Key1 { get; }
        protected string Bigrams { get; }
        protected char[,] Table1 { get; }
        protected int Rows { get; }
        protected int Cols { get; }

        public override string GetAbc() => Abc;
        public override string GetMessage() => Message;
        public override string GetKey1() => Key1;
        public override string GetBigrams() => Bigrams;
        public override char[,] GetTable1() => Table1;
        public override int GetRows() => Rows;
        public override int GetCols() => Cols;
        public override string GetCipher() => "Playfair";


        public PlayfairCipherStrategy(string abc, int row, int col, string message, string key1)
        {
            Abc = abc;
            Rows = row;
            Cols = col;
            Message = message.ToLower().Replace("j", "i");
            Key1 = key1;

            Table1 = UtilForTables.BuildTable(UtilForText.GetUniqLettersReplace(key1 + abc, abc), row, col);
            Bigrams = UtilForText.GetBigramText(message, abc);
        }

        public override string Encrypt()
        {
            StringBuilder result = new();
            for (int i = 0; i < Bigrams.Length; i += 2)
                result.Append(EncryptBigram(Bigrams[i], Bigrams[i + 1]));

            return result.ToString();
        }

        public override string Decrypt()
        {
            StringBuilder result = new();
            for (int i = 0; i < Bigrams.Length; i += 2)
                result.Append(DecryptBigram(Bigrams[i], Bigrams[i + 1]));

            return result.ToString();
        }

        private string EncryptBigram(char a, char b)
        {
            var (r1, c1) = UtilForTables.FindPosition(Table1, a);
            var (r2, c2) = UtilForTables.FindPosition(Table1, b);

            if (r1 == r2) 
            {
                return $"{Table1[r1, (c1 + 1) % Cols]}{Table1[r2, (c2 + 1) % Cols]}";
            }
            else if (c1 == c2) 
            {
                return $"{Table1[(r1 + 1) % Rows, c1]}{Table1[(r2 + 1) % Rows, c2]}";
            }
            else 
            {
                return $"{Table1[r1, c2]}{Table1[r2, c1]}";
            }
        }
        private string DecryptBigram(char a, char b)
        {
            var (r1, c1) = UtilForTables.FindPosition(Table1, a);
            var (r2, c2) = UtilForTables.FindPosition(Table1, b);

            if (r1 == r2) 
            {
                return $"{Table1[r1, (c1 + Cols - 1) % Cols]}{Table1[r2, (c2 + Cols - 1) % Cols]}";
            }
            else if (c1 == c2) 
            {
                return $"{Table1[(r1 + Rows - 1) % Rows, c1]}{Table1[(r2 + Rows - 1) % Rows, c2]}";
            }
            else 
            {
                return $"{Table1[r1, c2]}{Table1[r2, c1]}";
            }
        }

    }
}
