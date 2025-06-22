namespace CiphersWithPatterns
{
    public class CipherContext
    {
        private ICipherStrategy strategy;

        public CipherContext(ICipherStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(ICipherStrategy newStrategy)
        {
            strategy = newStrategy;
        }

        public string Encrypt()
        {
            return strategy.Encrypt();
        }

        public string Decrypt(string encryptMessage)
        {
            return strategy.Decrypt(encryptMessage);
        }

        public ICipherStrategy Strategy => strategy;
    }
}
