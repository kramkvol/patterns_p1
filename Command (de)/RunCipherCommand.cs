using System;
using ThePlayfairCipher;

namespace CiphersWithPatterns
{
    public class RunCipherCommand : ICipherCommand
    {
        private readonly string type;
        private readonly string abc;
        private readonly int rows;
        private readonly int cols;
        private readonly string message;
        private readonly string key1;
        private readonly string key2;
        private readonly ILogger logger;

        public RunCipherCommand(string type, string abc, int rows, int cols, string message, string key1, string key2, ILogger logger)
        {
            this.type = type;
            this.abc = abc;
            this.rows = rows;
            this.cols = cols;
            this.message = message;
            this.key1 = key1;
            this.key2 = key2;
            this.logger = logger;
        }

        public void Execute()
        {
            try
            {
                logger.LogInfo($"Running {type} cipher...");

                var baseCipher = CipherFactoryMethod.Create(type, abc, rows, cols, message, key1, key2);

                var cipher = new DebugCipherDecorator(baseCipher);
                DebugCipherConsole.Print(cipher);

                var context = new CipherContext(cipher);
                string encrypted = context.Encrypt();
                string decrypted = context.Decrypt(encrypted);
                string cleaned = context.CleanDecrypt(decrypted);

                logger.LogSuccess($"{type} cipher completed successfully.\n");
                
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception in {type} cipher: {ex.Message}");
            }
        }
    }

}
