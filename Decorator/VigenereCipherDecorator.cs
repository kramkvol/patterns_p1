using Ciphers.Core;
using Ciphers.Singletone;
using System;

namespace Ciphers.Decorator
{
    public class VigenereCipherDecorator : BaseCipherDecorator
    {
        public VigenereCipherDecorator(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public void PrintGeneralInf()
        {
            string preprocess_message = UtilForText.GetOnlyLetters(inner.GetMessage());
            string preprocess_key = UtilForText.GetRepeatedKey(inner.GetMessage(), inner.GetKey1());

            logger.LogCharpter("Cipher Debug Info:");
            logger.LogDebug($"Alphabet: {inner.GetAbc().ToUpper()}");
            logger.LogDebug($"Message : {preprocess_message.ToUpper()}");
            logger.LogDebug($"Key     : {preprocess_key.ToUpper()}");
            UtilForDecorator.PrintVigenereTable(logger, inner.GetTable1());
        }

        public override void DebugEncryptCipher()
        {
            string str_message = UtilForText.GetOnlyLetters(inner.GetMessage());
            string str_key = UtilForText.GetRepeatedKey(inner.GetMessage(), inner.GetKey1());
            string str_result = inner.Encrypt();
            for (int i = 0; i < str_result.Length; i ++)
            {
                logger.LogDebug($"[{str_message[i]}, {str_key[i]}] => [{str_result[i]}] ");
            }
        }

        public override void DebugDecryptCipher()
        {
            string str_message = UtilForText.GetOnlyLetters(inner.GetMessage());
            string str_key = UtilForText.GetRepeatedKey(inner.GetMessage(), inner.GetKey1());
            string str_result = inner.Decrypt();
            for (int i = 0; i < str_result.Length; i++)
            {
                logger.LogDebug($"[{str_message[i]}, {str_key[i]}] => [{str_result[i]}] ");
            }
        }
    }
}
