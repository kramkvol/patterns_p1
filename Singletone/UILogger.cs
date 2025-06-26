namespace CiphersWithPatterns
{
    public class UILogger : ILogger
    {
        private MainForm form;

        public UILogger(MainForm form) => this.form = form;
        

        public void LogInfo(string message) => form.Log("[INFO] " + message);
        public void LogResult(string message) => form.Log("[RESULT] " + message);
        public void LogError(string message) => form.Log("[ERROR] " + message);
        public void LogSuccess(string message) => form.Log("[SUCCESS] " + message);
        public void LogDebug(string message) => form.Log("[DEBUG] " + message);
        public void LogCharpter(string message) => form.Log("[CHAPTER] " + message);
        public void LogRequirement(string message) => form.Log("[REQUIREMENT] " + message);
        public void LogBase(string message) => form.Log(message);
        public void LogBaseLine(string message) => form.Log(message + "\n");
    }
}
