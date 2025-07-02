using Ciphers.Core;
using Ciphers.Singletone;
using Ciphers.Strategy;

namespace Ciphers.Decorator
{
    public class VigenereCipherDecorator : BaseCipherDecorator
    {
        public VigenereCipherDecorator(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public void PrintGeneralInf()
        {
            string preprocess_message = UtilForText.GetOnlyLetters(inner.GetMessege());
            string preprocess_key = UtilForText.GetRepeatedKey(inner.GetMessege(), inner.GetKey1());

            logger.LogCharpter("Cipher Debug Info:");
            logger.LogDebug($"Alphabet: {inner.GetAbc().ToUpper()}");
            logger.LogDebug($"Message : {preprocess_message.ToUpper()}");
            logger.LogDebug($"Key     : {preprocess_key.ToUpper()}");
            UtilForDecorator.PrintVigenereTable(logger, inner.GetTable1());
        }
    }
}
