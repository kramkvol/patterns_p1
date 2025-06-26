namespace CiphersWithPatterns
{
    public class CipherContext
    {
        private ICipherStrategy strategy;

        public CipherContext(ICipherStrategy strategy) => 
            this.strategy = strategy;

        public void SetStrategy(ICipherStrategy newStrategy) =>
            this.strategy = newStrategy;

        public string Encrypt() => 
            this.strategy.Encrypt();

        public string Decrypt() => 
            this.strategy.Decrypt();

        public string CleanDecrypt() => 
            this.strategy.CleanDecrypt();

        public ICipherStrategy Strategy 
            => strategy;
    }
}
