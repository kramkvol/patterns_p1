using CiphersWithPatterns;
namespace ThePlayfairCipher
{
    public class LoggingCipherDecorator : ICipherStrategy
    {
        private readonly ICipherStrategy inner;
        private readonly ILogger logger = ConsoleLogger.Instance;

        public string type => inner.type;
        public string abc => inner.abc;
        public int rows => inner.rows;
        public int cols => inner.cols;
        public string message => inner.message;
        public string key1 => inner.key1;
        public string key2 => inner.key2;
        public string cleanKey1 => inner.cleanKey1;
        public string cleanKey2 => inner.cleanKey2;
        public char[,] table1 => inner.table1;
        public char[,] table2 => inner.table2;
        public string bigrams => inner.bigrams;

        public LoggingCipherDecorator(ICipherStrategy inner) => this.inner = inner;
        
        public void printLog()
        {
            PrintGeneralInf();
            if (bigrams != null) { PrintBigrams(); }
            if (table1 != null && key1 != null) { PrintTable(table1, key1); }
            if (table2 != null && key2 != null) { PrintTable(table2, key2); }
        }

        public string Encrypt()
        {
            logger.LogInfo("Starting encryption...");
            var result = inner.Encrypt();
            logger.LogResult($"Encrypted: {result}");
            return result;
        }

        public string Decrypt(string encrypted)
        {
            logger.LogInfo("Starting decryption...");
            var result = inner.Decrypt(encrypted);
            logger.LogResult($"Decrypted: {result}");
            return result;
        }

        public string CleanDecrypt(string decrypted)
        {
            logger.LogInfo("Starting clean decryption...");
            var result = inner.CleanDecrypt(decrypted);
            logger.LogResult($"Clean Decrypted: {result}");
            return result;
        }

        private void PrintGeneralInf()
        {
            logger.LogCharpter("Cipher Debug Info:");
            if (!string.IsNullOrWhiteSpace(abc))
                logger.LogDebug($"Alphabet      : {abc}");
            if (rows > 0 && cols > 0)
                logger.LogDebug($"Table size    : {rows} x {cols}");
            if (!string.IsNullOrWhiteSpace(message))
                logger.LogDebug($"Original Msg  : {message}");
            if (!string.IsNullOrWhiteSpace(key1))
                logger.LogDebug($"Key 1         : {key1}");
            if (!string.IsNullOrWhiteSpace(key2))
                logger.LogDebug($"Key 2         : {key2}");
            if (!string.IsNullOrWhiteSpace(cleanKey1))
                logger.LogDebug($"Cleankey1     : {cleanKey1}");
            if (!string.IsNullOrWhiteSpace(cleanKey2))
                logger.LogDebug($"Cleankey2     : {cleanKey2}");
        }

        private void PrintBigrams()
        {
            logger.LogCharpter("Bigrams:");
            for (int i = 0, count = 0; i < bigrams.Length - 1; i += 2)
            {
                logger.LogDebug($"{bigrams[i]} {bigrams[i + 1]} | ");
                if (++count % 8 == 0) logger.LogBaseLine("");
            }
            logger.LogBaseLine("");
        }

        private void PrintTable(char[,] table, string key)
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