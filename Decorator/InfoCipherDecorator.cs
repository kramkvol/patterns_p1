using System.Windows.Forms;

namespace CiphersWithPatterns
{
    public class InfoCipherDecorator 
    {
        protected ICipherStrategy inner;
        protected ILogger logger;

        public InfoCipherDecorator(ICipherStrategy inner, ILogger logger)
        {
            this.inner = inner;
            this.logger = logger;
        }
        public void PrintGeneralInf()
        {
            logger.LogCharpter("Cipher Debug Info:");
            if (!string.IsNullOrWhiteSpace(inner.getAbc()))
                logger.LogDebug($"Alphabet      : {inner.getAbc()}");
            if (inner.getRow() > 0 && inner.getCol() > 0)
                logger.LogDebug($"Table size    : {inner.getRow()} x {inner.getCol()}");
            if (!string.IsNullOrWhiteSpace(inner.getMessege()))
                logger.LogDebug($"Original Msg  : {inner.getMessege()}");
            if (!string.IsNullOrWhiteSpace(inner.getKey1()))
                logger.LogDebug($"Key 1         : {inner.getKey1()}");
            if (!string.IsNullOrWhiteSpace(inner.getKey2()))
                logger.LogDebug($"Key 2         : {inner.getKey2()}");
            if (!string.IsNullOrWhiteSpace(inner.getCleanKey1()))
                logger.LogDebug($"Cleankey1     : {inner.getCleanKey1()}");
            if (!string.IsNullOrWhiteSpace(inner.getCleanKey2()))
                logger.LogDebug($"Cleankey2     : {inner.getCleanKey2()}");
        }

        public void PrintBigrams()
        {
            logger.LogCharpter("Bigrams:");
            for (int i = 0, count = 0; i < inner.getBigramms().Length - 1; i += 2)
            {
                logger.LogDebug($"{inner.getBigramms()[i]} {inner.getBigramms()[i + 1]} | ");
                if (++count % 8 == 0) logger.LogBaseLine("");
            }
            logger.LogBaseLine("");
        }

        public void PrintTable(char[,] table, string key)
        {
            logger.LogCharpter($"Table for key '{key}':");
            for (int r = 0; r < table.GetLength(0); r++)
            {
                for (int c = 0; c < table.GetLength(1); c++)
                {
                    logger.LogBase(table[r, c] + " ");
                }
                logger.LogBaseLine("");
            }
        }
    }
}

