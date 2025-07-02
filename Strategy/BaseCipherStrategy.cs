using System.Text;
using System.Windows.Forms;

namespace Ciphers.Strategy
{
    public abstract class BaseCipherStrategy : ICipherStrategy
    {
        protected string Abc { get; set; }
        protected int Rows { get; set;}
        protected int Cols { get; set;}
        protected string Message { get; set; }
        protected string Key1 { get; set; }
        protected string Key2 { get; set; }
        protected char[,] Table1 { get; set; }
        protected char[,] Table2 { get; set; }
        protected string Bigrams { get; set; }

        public BaseCipherStrategy(string abc, string message, string key1) 
        {
            Abc = abc;
            Message = message;
            Key1 = key1;
        }
        public BaseCipherStrategy(string abc, int row, int col, string message, string key1) 
        {
            Abc = abc;
            Message = message;
            Key1 = key1;
            Rows = row;
            Cols = col;
        }
        public BaseCipherStrategy(string abc, string message, int rows, int cols, string key1, string key2) 
        {
            Abc = abc;
            Message = message;
            Key1 = key1;
            Key2 = key2;
            Rows = rows;
            Cols = cols;
        }
        public virtual string GetMessege() => Message;
        public virtual string GetAbc() => Abc;
        public virtual int GetRow() => Rows;
        public virtual int GetCol() => Cols;
        public virtual string GetKey1() => Key1;
        public virtual string GetKey2() => Key2;
        public virtual string GetBigramms() => Bigrams;
        public virtual char[,] GetTable1() => Table1;
        public virtual char[,] GetTable2() => Table2;
        public virtual string GetCipher() => "base";
        public virtual string Encrypt() => Encrypt();
        public virtual string Decrypt() => Encrypt();
        public string CleanDecrypt() 
        {
            string decrypted = Decrypt();

            StringBuilder result = new();
            result.Append(decrypted);

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 'x' && i > 0)
                {
                    result.Replace(result[i], result[i - 1]);
                }
            }

            if (result.Length > 0 && result[^1] == 'z')
            {
                result.Remove(result.Length - 1, 1);
            }

            return result.ToString();
        }
    }
}
