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

        public string Decrypt(string encrypt) => 
            this.strategy.Decrypt(encrypt);

        public string CleanDecrypt(string decrypt) => 
            this.strategy.CleanDecrypt(decrypt);

        public ICipherStrategy Strategy 
            => strategy;
    }
}
