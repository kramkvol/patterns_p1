using Ciphers.Strategy;

namespace Ciphers.Core
{
    public class CipherContext
    {
        private readonly ICipherStrategy strategy;
        private readonly string action;

        public CipherContext(ICipherStrategy strategy, string action) {
            this.strategy = strategy;
            this.action = action;
        }
    }
}
