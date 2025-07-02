using Ciphers.Singletone;
using Ciphers.Strategy;

namespace Ciphers.Decorator
{
    public abstract class BaseCipherDecorator : ICipherStrategy
    {
        protected ICipherStrategy inner;
        protected ILogger logger;
        public string GetCipher() => inner.GetCipher();
        public string GetMessege() => inner.GetMessege();
        public string GetAbc() => inner.GetAbc();
        public int GetRow() => inner.GetRow();
        public int GetCol() => inner.GetCol();
        public string GetKey1() => inner.GetKey1();
        public string GetKey2() => inner.GetKey2();
        public string GetBigramms() => inner.GetBigramms();
        public char[,] GetTable1() => inner.GetTable1();
        public char[,] GetTable2() => inner.GetTable2();

        public BaseCipherDecorator(ICipherStrategy inner, ILogger logger)
        {
            this.inner = inner;
            this.logger = logger;
        }

        public string Encrypt()
        {
            logger.LogInfo("Encryption started...");
            var result = inner.Encrypt();
            logger.LogResult($"Encrypted: {result}");
            return result;
        }
        public string Decrypt()
        {
            logger.LogInfo("Decryption started...");
            var result = inner.Decrypt();
            logger.LogResult($"Decrypted: {result}");
            return result;
        }
        public string CleanDecrypt()
        {
            logger.LogInfo("Clean Decryption started...");
            var result = inner.CleanDecrypt().ToLower();
            logger.LogResult($"Clean Decrypted: {result}");
            return result;
        }

    }

}
