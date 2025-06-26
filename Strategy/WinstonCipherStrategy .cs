using CiphersWithPatterns;
using System;
using System.Text;
public class WinstonCipherStrategy : ICipherStrategy
{
    private string type { get; }
    private string abc { get; }
    private int rows { get; }
    private int cols { get; }
    public string message;
    private string key1 { get; }
    private string key2 { get; }
    private string cleanKey1 { get; }
    private string cleanKey2 { get; }
    private char[,] table1 { get; }
    private char[,] table2 { get; }
    private string bigrams { get; }

    public WinstonCipherStrategy(string abc, string message, int rows, int cols, string key1, string key2)
    {
        this.abc = abc;
        this.rows = rows;
        this.cols = cols;
        this.message = message;
        this.key1 = key1;
        this.key2 = key2;

        cleanKey1 = CipherTextPreprocessor.GetUniqLettersReplace(key1 + abc, abc);
        cleanKey2 = CipherTextPreprocessor.GetUniqLettersReplace(key2 + abc, abc);

        table1 = CipherTableBuilder.BuildTable(cleanKey1, rows, cols);
        table2 = CipherTableBuilder.BuildTable(cleanKey2, rows, cols);

        bigrams = CipherTextPreprocessor.GetBigramText(this.message, abc);
    }

    public string Encrypt()
    {
        StringBuilder encrypted = new StringBuilder();
        for (int i = 0; i < bigrams.Length; i += 2)
        {
            encrypted.Append(EncryptBigram(bigrams[i], bigrams[i + 1]));
        }
        return encrypted.ToString();
    }

    public string Decrypt()
    {
        string cipherText = CipherTextPreprocessor.GetOnlyLetters(message);
        StringBuilder restored = new StringBuilder();
        for (int i = 0; i < cipherText.Length; i += 2)
        {
            restored.Append(DecryptBigram(cipherText[i], cipherText[i + 1]));
        }
        return restored.ToString();
    }

    public string CleanDecrypt()
    {
        string decrypt = CipherTextPreprocessor.GetOnlyLetters(message);
        return CipherTextPreprocessor.PostprocessDecrypted(decrypt);
    }

    private (int row, int col) FindPosition(char[,] table, char c)
    {
        for (int r = 0; r < table.GetLength(0); r++)
            for (int col = 0; col < table.GetLength(1); col++)
                if (table[r, col] == c)
                    return (r, col);
        throw new Exception($"Character {c} not found.");
    }

    private string EncryptBigram(char a, char b)
    {
        var (r1, c1) = FindPosition(table1, a);
        var (r2, c2) = FindPosition(table2, b);

        char encA = table1[r1, cols - 1 - c1];
        char encB = table2[r2, cols - 1 - c2];

        return $"{encA}{encB}";
    }

    private string DecryptBigram(char a, char b)
    {
        var (r1, c1) = FindPosition(table1, a);
        var (r2, c2) = FindPosition(table2, b);

        char decA = table1[r1, cols - 1 - c1];
        char decB = table2[r2, cols - 1 - c2];

        return $"{decA}{decB}";
    }

    public string getType()
    {
        return type;
    }
    public string getMessege()
    {
        return message;
    }
    public string getAbc()
    {
        return abc;
    }
    public int getRow()
    {
        return rows;
    }
    public int getCol()
    {
        return cols;
    }
    public string getKey1()
    {
        return key1;
    }
    public string getKey2()
    {
        return key2;
    }
    public string getCleanKey1()
    {
        return cleanKey1;
    }
    public string getCleanKey2()
    {
        return cleanKey2;
    }
    public string getBigramms()
    {
        return bigrams;
    }
    public char[,] getTable1()
    {
        return table1;
    }
    public char[,] getTable2()
    {
        return table2;
    }
}
