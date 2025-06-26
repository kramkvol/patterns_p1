namespace CiphersWithPatterns
{
    public class ResultCipherDecorator : BaseCipherDecorator
    {
        public ResultCipherDecorator(ICipherStrategy inner, ILogger logger) : base(inner, logger) { }

        public override string Encrypt()
        {
            logger.LogInfo("Encryption started.");
            var result = base.Encrypt();
            logger.LogResult($"Encrypted: {result}");
            return result;
        }

        public override string Decrypt()
        {
            logger.LogInfo("Decryption started.");
            var result = base.Decrypt();
            logger.LogResult($"Decrypted: {result}");
            return result;
        }

        public override string CleanDecrypt()
        {
            logger.LogInfo("Clean Decryption started.");
            var result = base.CleanDecrypt();
            logger.LogResult($"Clean Decrypted: {result}");
            return result;
        }
    }
}

