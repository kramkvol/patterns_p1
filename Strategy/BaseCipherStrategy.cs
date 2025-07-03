using Ciphers.Core;
using System;
using System.Text;
using System.Windows.Forms;

namespace Ciphers.Strategy
{
    public abstract class BaseCipherStrategy : ICipherStrategy
    {

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

        public virtual string Encrypt()
        {
            throw new NotImplementedException("Encrypt() must be implemented in the derived class.");
        }

        public virtual string Decrypt()
        {
            throw new NotImplementedException("Decrypt() must be implemented in the derived class.");
        }

        public virtual string CleanDecrypt()
        {
            string decrypted = Decrypt();

            StringBuilder result = new();
            result.Append(decrypted);

            for (int i = 1; i < result.Length - 1; i += 2)
            {
                if (result[i] == 'x' && i > 0)
                {
                    result[i] = result[i - 1];
                }
            }

            if (result.Length > 0 && result[^1] == 'z')
            {
                result.Remove(result.Length - 1, 1);
            }

            return result.ToString();
        }

    }
}
