namespace CiphersWithPatterns
{
    public interface ICipherStrategy
    {
        string getType();
        string getMessege();
        string getAbc();
        int getRow();
        int getCol();
        string getBigramms();
        string getKey1();
        string getKey2();
        string getCleanKey1();
        string getCleanKey2();
        char[,] getTable1();
        char[,] getTable2();

        string Encrypt();
        string Decrypt();
        string CleanDecrypt();
    }
}
