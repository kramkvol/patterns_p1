using Ciphers.Core;
using Ciphers.Singletone;
using Ciphers.Strategy;

namespace Ciphers.Decorator
{
    public class WinstonCipherDecorator : BaseCipherDecorator
    {
        public WinstonCipherDecorator(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public void PrintGeneralInf()
        {
            string preprocess_message = UtilForText.GetOnlyLetters(inner.GetMessege());
            string preprocess_key1 = UtilForText.GetOnlyLetters(inner.GetKey1());
            string preprocess_key2 = UtilForText.GetOnlyLetters(inner.GetKey2());
            string preprocess_bigrams = UtilForDecorator.GetFormed(inner.GetBigramms());

            logger.LogCharpter("Cipher Debug Info:");
            logger.LogDebug($"Alphabet: {inner.GetAbc()}");
            logger.LogDebug($"Message : {preprocess_message.ToUpper()}");
            logger.LogDebug($"Key1    : {preprocess_key1.ToUpper()}");
            logger.LogDebug($"Key2    : {preprocess_key2.ToUpper()}");
            logger.LogDebug($"Bigramms: {preprocess_bigrams.ToUpper()}");
            UtilForDecorator.PrintTable(logger, inner.GetTable1(), preprocess_key1);
            UtilForDecorator.PrintTable(logger, inner.GetTable2(), preprocess_key2);
        }
    }
}
