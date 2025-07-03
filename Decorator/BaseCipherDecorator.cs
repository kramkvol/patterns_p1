using Ciphers.Core;
using Ciphers.Singletone;

namespace Ciphers.Decorator
{
    public abstract class BaseCipherDecorator : ICipherStrategy
    {
        protected ICipherStrategy inner;
        protected ILogger logger;
        public virtual string GetMessage() => null;
        public virtual string GetKey1() => null;
        public virtual string GetKey2() => null;
        public virtual string GetBigrams() => null;
        public virtual char[,] GetTable1() => null;
        public virtual char[,] GetTable2() => null;
        public virtual string GetAbc() => null;
        public virtual int GetRows() => 0;
        public virtual int GetCols() => 0;
        public virtual string GetCipher() => null;

        public BaseCipherDecorator(ICipherStrategy inner, ILogger logger)
        {
            this.inner = inner;
            this.logger = logger;
        }

        public string Encrypt()
        {
            logger.LogInfo("Encryption started...");
            var result = inner.Encrypt();
            DebugEncryptCipher();
            logger.LogResult($"Encrypted: {result}");
            return result;
        }

        public string Decrypt()
        {
            logger.LogInfo("Decryption started...");
            var result = inner.Decrypt();
            DebugDecryptCipher();
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

        public virtual void DebugEncryptCipher() { }
        public virtual void DebugDecryptCipher() { }
    }

}