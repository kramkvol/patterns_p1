using Ciphers.UI;
using System;

namespace Ciphers.Singletone
{
    public class UILogger : ILogger
    {
        private static UILogger? instance;
        public static UILogger Instance
        {
            get
            {
                if (instance == null)
                    throw new InvalidOperationException("UILogger is not initialized. Call Initialize(form) first.");
                return instance;
            }
        }

        private readonly CipherForm form;

        private UILogger(CipherForm form)
        {
            this.form = form;
        }

        public static void Initialize(CipherForm form)
        {
            if (instance == null)
                instance = new UILogger(form);
            else
                throw new InvalidOperationException("UILogger is already initialized.");
        }
        public void LogInfo(string message) => form.Log("[INFO] " + message);
        public void LogResult(string message) => form.ShowResult("[RESULT] " + message);
        public void LogError(string message) => form.Log("[ERROR] " + message);
        public void LogSuccess(string message) => form.Log("[SUCCESS] " + message);
        public void LogDebug(string message) => form.Log("[DEBUG] " + message);
        public void LogCharpter(string message) => form.Log("[CHAPTER] " + message);
        public void LogRequirement(string message) => form.Log("[REQUIREMENT] " + message);
        public void LogBaseLine(string message) => form.Log(message + "\n");
    }
}
