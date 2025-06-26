using System.Windows.Forms;

namespace CiphersWithPatterns
{
    public abstract class BaseCipherDecorator : ICipherStrategy
    {
        protected ICipherStrategy inner;
        protected ILogger logger;
        public BaseCipherDecorator(ICipherStrategy inner, ILogger logger) {
            this.inner = inner;
            this.logger = logger;
        }
        public virtual string Encrypt() => inner.Encrypt();
        public virtual string Decrypt() => inner.Decrypt();
        public virtual string CleanDecrypt() => inner.CleanDecrypt();

        public string getType()
        {
            return inner.getType();
        }
        public string getMessege()
        {
            return inner.getMessege();
        }
        public int getRow()
        {
            return inner.getRow();
        }

        public int getCol()
        {
            return inner.getCol();
        }
        public string getAbc()
        {
            return inner.getAbc();
        }
        public string getKey1()
        {
            return inner.getKey1();
        }
        public string getKey2()
        {
            return inner.getKey2();
        }
        public string getCleanKey1()
        {
            return inner.getCleanKey1();
        }
        public string getCleanKey2()
        {
            return inner.getCleanKey2();
        }
        public string getBigramms()
        {
            return inner.getBigramms();
        }
        public char[,] getTable1()
        {
            return inner.getTable1();
        }
        public char[,] getTable2()
        {
            return inner.getTable2();
        }
    }

}
