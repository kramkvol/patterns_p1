namespace Ciphers.Core
{
    public interface ICipherStrategy
    {
        string GetCipher();
        string GetMessage();
        string GetKey1();
        string GetKey2();
        string GetBigrams();
        char[,] GetTable1();
        char[,] GetTable2();
        string GetAbc();
        int GetRows();
        int GetCols();

        string Encrypt();
        string Decrypt();
        string CleanDecrypt();
    }
}
