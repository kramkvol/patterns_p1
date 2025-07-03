using Ciphers.Core;
using System;
using System.Text;

namespace Ciphers.Strategy
{
    class VigenereCipherStrategy : BaseCipherStrategy
    {
        protected string Abc { get; }
        protected string Message { get; }
        protected string Key1 { get; }
        protected char[,] Table1 { get; }

        public override string GetAbc() => Abc;
        public override string GetMessage() => Message;
        public override string GetKey1() => Key1;
        public override char[,] GetTable1() => Table1;
        public override string GetCipher() => "Vigenere";

        public VigenereCipherStrategy(string abc, string message, string key1) 
        {
            this.Abc = abc;
            this.Message = message;
            this.Key1 = key1;
            Table1 = UtilForTables.BuildVigenereTable(abc, abc.Length);
        }

        public override string Encrypt()
        {
            string preprocess_message = UtilForText.GetOnlyLetters(Message.ToLower());
            string preprocess_key = UtilForText.GetRepeatedKey(preprocess_message, GetKey1());

            StringBuilder result = new();
            for (int i = 0; i < preprocess_message.Length; i++)
            {
                result.Append(EncryptChar(preprocess_message[i], preprocess_key[i]));
            }

            return result.ToString();
        }

        public override string Decrypt()
        {
            string cipherText = UtilForText.GetOnlyLetters(Message.ToLower());
            string preprocess_key = UtilForText.GetRepeatedKey(cipherText, GetKey1());

            StringBuilder result = new();
            for (int i = 0; i < cipherText.Length; i++)
            {
                result.Append(DecryptChar(cipherText[i], preprocess_key[i]));
            }

            return result.ToString();
        }


        private char EncryptChar(char plainChar, char keyChar)
        {
            int row = Abc.IndexOf(char.ToLower(keyChar));
            int col = Abc.IndexOf(char.ToLower(plainChar));

            return Table1[row, col];
        }

        private char DecryptChar(char cipherChar, char keyChar)
        {
            int row = Abc.IndexOf(char.ToLower(keyChar));

            for (int col = 0; col < Abc.Length; col++)
            {
                if (Table1[row, col] == cipherChar)
                    return Abc[col];
            }

            throw new Exception($"Character {cipherChar} not found in Vigenere row.");
        }

    }

}
