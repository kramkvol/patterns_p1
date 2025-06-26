using System.Linq;
using System.Text;

namespace CiphersWithPatterns
{
    class VigenereCipherStrategy : ICipherStrategy
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
        public string getKey1()
        {
            return key1;
        }
        public string getKey2()
        {
            return null;
        }
        public int getRow()
        {
            return 0;
        }
        public int getCol()
        {
            return 0;
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

        public VigenereCipherStrategy(string abc, string message, string key1)
        {
            this.abc = abc;
            this.message = message;
            this.key1 = key1;
            rows = abc.Length;
            cols = abc.Length;
            cleanKey1 = CipherTextPreprocessor.GetLongKey(message, key1);
            table1 = CipherTableBuilder.BuildVigenereTable(abc, rows);
        }

        public string Encrypt()
        {
            string cleanMessage = new string(message.Where(c => abc.Contains(c)).ToArray());
            string longKey = CipherTextPreprocessor.GetLongKey(cleanMessage, key1);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < cleanMessage.Length; i++)
            {
                int msgIndex = abc.IndexOf(cleanMessage[i]);
                int keyIndex = abc.IndexOf(longKey[i]);
                int encIndex = (msgIndex + keyIndex) % abc.Length;
                result.Append(abc[encIndex]);
            }

            return result.ToString();
        }
        public string Decrypt()
        {
            string encrypted = CipherTextPreprocessor.GetOnlyLetters(message);
            string longKey = CipherTextPreprocessor.GetLongKey(encrypted, key1);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < encrypted.Length; i++)
            {
                int encIndex = abc.IndexOf(encrypted[i]);
                int keyIndex = abc.IndexOf(longKey[i]);
                int msgIndex = (encIndex - keyIndex + abc.Length) % abc.Length;
                result.Append(abc[msgIndex]);
            }

            return result.ToString();
        }

        public string CleanDecrypt()
        {
            string decrypt = CipherTextPreprocessor.GetOnlyLetters(message);
            return CipherTextPreprocessor.PostprocessDecrypted(decrypt);
        }
    }

}
