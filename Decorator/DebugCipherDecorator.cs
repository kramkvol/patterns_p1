using CiphersWithPatterns;
using CiphersWithPatterns.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePlayfairCipher.Decorator
{
    public class DebugCipherDecorator : ICipherStrategy
    {
        private readonly ICipherStrategy _inner;
        private readonly ILogger _logger = ConsoleLogger.Instance;

        public DebugCipherDecorator(ICipherStrategy inner)
        {
            _inner = inner;
        }

        public string Encrypt()
        {
            _logger.LogInfo("Starting encryption...");
            var result = _inner.Encrypt();
            _logger.LogResult($"Encrypted: {result}");
            return result;
        }

        public string Decrypt(string encrypted)
        {
            _logger.LogInfo("Starting decryption...");
            var result = _inner.Decrypt(encrypted);
            _logger.LogResult($"Decrypted: {result}");
            return result;
        }

        public string CleanDecrypt(string decrypted)
        {
            _logger.LogInfo("Starting clean decryption...");
            var result = _inner.CleanDecrypt(decrypted);
            _logger.LogResult($"Clean Decrypted: {result}");
            return result;
        }

        public string abc => _inner.abc;
        public int rows => _inner.rows;
        public int cols => _inner.cols;
        public string message => _inner.message;
        public string key1 => _inner.key1;
        public string key2 => _inner.key2;
        public string cleanKey1 => _inner.cleanKey1;
        public string cleanKey2 => _inner.cleanKey2;
        public char[,] table1 => _inner.table1;
        public char[,] table2 => _inner.table2;
        public string bigrams => _inner.bigrams;
    }

}
