using System;

namespace CiphersWithPatterns
{
    public class CreateCipherCommand : ICipherCommand
    {
        private readonly string type;
        private readonly string abc;
        private readonly int rows;
        private readonly int cols;
        private readonly string message;
        private readonly string key1;
        private readonly string key2;

        public CreateCipherCommand(string type, string abc, int rows, int cols, string message, string key1, string key2)
        {
            this.type = type;
            this.abc = abc;
            this.rows = rows;
            this.cols = cols;
            this.message = message;
            this.key1 = key1;
            this.key2 = key2;
        }

        public void Execute()
        {
            var logger = ConsoleLogger.Instance;
            try
            {
                logger.LogInfo($"Create {type} cipher...");
                var baseCipher = CipherFactoryMethod.Create(type, abc, rows, cols, message, key1, key2);
                logger.LogSuccess($"{type} cipher created successfully.\n");
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception in creating {type} cipher: {ex.Message}");
            }
        }
    }
}
