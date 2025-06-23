using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiphersWithPatterns
{
    public class UILogger 
    {
        private MainForm form;

        public UILogger(MainForm form)
        {
            this.form = form;
        }

        public void LogInfo(string message) => form.Log("[INFO] " + message);
        public void LogResult(string message) => form.ShowResult(message);
        public void LogError(string message) => form.Log("[ERROR] " + message);
    }
}
