using System.Linq;
using System.Text;
using CiphersWithPatterns.Core;

namespace CiphersWithPatterns
{
    class VigenereCipherStrategy : ICipherStrategy, ICipherMetadata
    {
        public string abc { get; }
        public int rows { get; }
        public int cols { get; }
        public string message { get; }

        public string key1 { get; }
        public string cleanKey1 { get; } 

        public string key2 { get; } = null;
        public string cleanKey2 { get; } = null;
        public char[,] table1 { get; }
        public char[,] table2 { get; } = null;
        public string bigrams { get; } = null;

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

        public string Decrypt(string encrypted)
        {
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


    }

}
