namespace Ciphers.Strategy
{
    public interface ICipherStrategy
    {
        string GetCipher();
        string GetMessege();
        string GetAbc();
        int GetRow();
        int GetCol();
        string GetBigramms();
        string GetKey1();
        string GetKey2();

        char[,] GetTable1();
        char[,] GetTable2();


        string Encrypt();
        string Decrypt();
        string CleanDecrypt();
    }
}
