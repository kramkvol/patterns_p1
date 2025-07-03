using Ciphers.Core;
using Ciphers.Singletone;
using Ciphers.Strategy;
using System.Text;

namespace Ciphers.Decorator
{
    public class PlayfairCipherDecorator : BaseCipherDecorator
    {
        public PlayfairCipherDecorator(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public void PrintGeneralInf()
        {
            string preprocess_message = UtilForText.GetOnlyLetters(inner.GetMessage());
            string preprocess_key1 = UtilForText.GetOnlyLetters(inner.GetKey1());
            string preprocess_bigrams = UtilForDecorator.GetFormed(inner.GetBigrams());

            logger.LogCharpter("Cipher Debug Info:");
            logger.LogDebug($"Alphabet: {inner.GetAbc().ToUpper()}");
            logger.LogDebug($"Message : {preprocess_message.ToUpper()}");
            logger.LogDebug($"Key1    : {preprocess_key1.ToUpper()}");
            logger.LogDebug($"Bigramms: {preprocess_bigrams.ToUpper()}");
            UtilForDecorator.PrintTable(logger, inner.GetTable1(), preprocess_key1);
        }


        public override void DebugEncryptCipher()
        {
            string str_bigram = inner.GetBigrams();
            string str_result = inner.Encrypt();
            for (int i = 0; i < str_bigram.Length; i+=2)
            {
                logger.LogDebug($"[{str_bigram[i]}, {str_bigram[i + 1]}] => [{str_result[i]}, {str_result[i+1]}] ");
            }
        }

        public override void DebugDecryptCipher()
        {
            string str_bigram = inner.GetBigrams();
            string str_result = inner.Decrypt();
            for (int i = 0; i < str_bigram.Length; i += 2)
            {
                logger.LogDebug($"[{str_bigram[i]}, {str_bigram[i + 1]}] => [{str_result[i]}, {str_result[i+1]}] ");
            }
        }
    }
}
