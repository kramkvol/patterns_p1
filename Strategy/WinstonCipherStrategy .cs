using Ciphers.Core;
using System;
using System.Text;

namespace Ciphers.Strategy
{
    public class WinstonCipherStrategy : BaseCipherStrategy
    {
        protected string Abc { get; }
        protected string Message { get; }
        protected string Key1 { get; }
        protected string Key2 { get; }
        protected string Bigrams { get; }
        protected char[,] Table1 { get; }
        protected char[,] Table2 { get; }
        protected int Rows { get; }
        protected int Cols { get; }

        public override string GetAbc() => Abc;
        public override string GetMessage() => Message;
        public override string GetKey1() => Key1;
        public override string GetKey2() => Key2;
        public override string GetBigrams() => Bigrams;
        public override char[,] GetTable1() => Table1;
        public override char[,] GetTable2() => Table2;
        public override int GetRows() => Rows;
        public override int GetCols() => Cols;
        public override string GetCipher() => "Winston";

        public WinstonCipherStrategy(string abc, string message, int rows, int cols, string key1, string key2)
        {
            this.Abc = abc;
            this.Rows = rows;
            this.Cols = cols;
            this.Message = message;
            this.Key1 = key1;
            this.Key2 = key2;

            Table1 = UtilForTables.BuildTable(UtilForText.GetUniqLettersReplace(key1 + abc, abc), rows, cols);
            Table2 = UtilForTables.BuildTable(UtilForText.GetUniqLettersReplace(key2 + abc, abc), rows, cols);

            Bigrams = UtilForText.GetBigramText(Message, abc);
        }
        public override string Encrypt()
        {
            StringBuilder result = new();
            for (int i = 0; i < Bigrams.Length; i += 2)
            {
                result.Append(SolveBigram(Bigrams[i], Bigrams[i + 1]));
            }
            return result.ToString();
        }

        public override string Decrypt()
        {
            return Encrypt();
        }

        private string SolveBigram(char a, char b)
        {
            var (r1, c1) = UtilForTables.FindPosition(Table1, a);
            var (r2, c2) = UtilForTables.FindPosition(Table2, b);

            char encA = Table1[r1, c2];
            char encB = Table2[r2, c1];

            return $"{encA}{encB}";
        }

    }
}