using Ciphers.Core;
using Ciphers.Singletone;

namespace Ciphers.Decorator
{
    public class WinstonCipherDecorator : BaseCipherDecorator
    {
        public WinstonCipherDecorator(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public void PrintGeneralInf()
        {
            string preprocess_message = UtilForText.GetOnlyLetters(inner.GetMessage());
            string preprocess_key1 = UtilForText.GetOnlyLetters(inner.GetKey1());
            string preprocess_key2 = UtilForText.GetOnlyLetters(inner.GetKey2());
            string preprocess_bigrams = UtilForDecorator.GetFormed(inner.GetBigrams());

            logger.LogCharpter("Cipher Debug Info:");
            logger.LogDebug($"Alphabet: {inner.GetAbc()}");
            logger.LogDebug($"Message : {preprocess_message.ToUpper()}");
            logger.LogDebug($"Key1    : {preprocess_key1.ToUpper()}");
            logger.LogDebug($"Key2    : {preprocess_key2.ToUpper()}");
            logger.LogDebug($"Bigramms: {preprocess_bigrams.ToUpper()}");
            UtilForDecorator.PrintTable(logger, inner.GetTable1(), preprocess_key1);
            UtilForDecorator.PrintTable(logger, inner.GetTable2(), preprocess_key2);
        }

        public override void DebugEncryptCipher()
        {
            string str_bigram = inner.GetBigrams();
            string str_result = inner.Encrypt();

            for (int i = 0; i < str_bigram.Length; i += 2)
            {
                logger.LogDebug($"Bigram: {str_bigram[i]}, in Table1 {UtilForTables.FindPosition(inner.GetTable1(), str_bigram[i])} -> Result: {str_result[i]}, in Table1 - {UtilForTables.FindPosition(inner.GetTable1(), str_result[i])}");
                logger.LogDebug($"Bigram: {str_bigram[i+1]}, in Table2 {UtilForTables.FindPosition(inner.GetTable2(), str_bigram[i+1])} -> Result: {str_result[i+1]}, in Table2 - {UtilForTables.FindPosition(inner.GetTable2(), str_result[i+1])}");

                if (i < str_bigram.Length-2)
                {
                    logger.LogDebug("");
                }
            }
        }
    }
}
