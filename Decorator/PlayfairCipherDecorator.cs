using Ciphers.Core;
using Ciphers.Singletone;
using Ciphers.Strategy;

namespace Ciphers.Decorator
{
    public class PlayfairCipherDecorator : BaseCipherDecorator
    {
        public PlayfairCipherDecorator(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public void PrintGeneralInf()
        {
            string preprocess_message = UtilForText.GetOnlyLetters(inner.GetMessege());
            string preprocess_key1 = UtilForText.GetOnlyLetters(inner.GetKey1());
            string preprocess_bigrams = UtilForDecorator.GetFormed(inner.GetBigramms());

            logger.LogCharpter("Cipher Debug Info:");
            logger.LogDebug($"Alphabet: {inner.GetAbc().ToUpper()}");
            logger.LogDebug($"Message : {preprocess_message.ToUpper()}");
            logger.LogDebug($"Key1    : {preprocess_key1.ToUpper()}");
            logger.LogDebug($"Bigramms: {preprocess_bigrams.ToUpper()}");
            UtilForDecorator.PrintTable(logger, inner.GetTable1(), preprocess_key1);
        }
    }
}
