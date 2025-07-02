using Ciphers.Core;
using System;
using System.Text;

namespace Ciphers.Strategy
{
    public class WinstonCipherStrategy : BaseCipherStrategy
    {
        public WinstonCipherStrategy(string abc, string message, int rows, int cols, string key1, string key2) : base(abc, message, rows, cols, key1, key2)
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
        public override string GetCipher() => "Winston";
        public override string Encrypt()
        {
            StringBuilder result = new();
            for (int i = 0; i < Bigrams.Length; i += 2)
            {
                result.Append(SolveBigram(Bigrams[i], Bigrams[i + 1]));
            }
            return result.ToString();
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