namespace CiphersWithPatterns
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string error);
        void LogResult(string message);
        void LogCharpter(string message);
        void LogSuccess(string message);
        void LogDebug(string message);
        void LogRequirement(string message);
    }

}
