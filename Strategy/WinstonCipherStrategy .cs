using System;
using System.Text;
using CiphersWithPatterns;

public class WinstonCipherStrategy : ICipherStrategy, ICipherMetadata
{
    public string abc { get; }
    public int rows { get; }
    public int cols { get; }
    public string message { get; }
    public string key1 { get; }
    public string key2 { get; }

    public string cleanKey1 { get; }
    public string cleanKey2 { get; }
    public char[,] table1 { get; }
    public char[,] table2 { get; }
    public string bigrams { get; }

    public WinstonCipherStrategy(string message, string abc, int rows, int cols, string key1, string key2)
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

    public string Decrypt(string cipherText)
    {
        StringBuilder restored = new StringBuilder();
        for (int i = 0; i < cipherText.Length; i += 2)
        {
            restored.Append(DecryptBigram(cipherText[i], cipherText[i + 1]));
        }
        return restored.ToString();
    }

    public string CleanDecrypt(string decrypt)
    {
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
}
