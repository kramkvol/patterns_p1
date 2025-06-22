namespace CiphersWithPatterns.Core
{
    public interface ICipherMetadata
    {
        string abc { get; }
        int rows { get; }
        int cols { get; }
        string message { get; }
        string key1 { get; }
        string key2 { get; }
        string cleanKey1 { get; }
        string cleanKey2 { get; }
        char[,] table1 { get; }
        char[,] table2 { get; }
        string bigrams { get; }
    }
}
