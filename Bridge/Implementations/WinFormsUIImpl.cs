using CiphersWithPatterns;
using System.Windows.Forms;
using ThePlayfairCipher.Bridge.Abstractions;

namespace ThePlayfairCipher.Bridge.Implementations
{
    public class WinFormsUIImpl : ICipherUIImpl
    {
        private MainForm form;

        public WinFormsUIImpl()
        {
            form = new MainForm();
        }

        public void DisplayMessage(string message)
        {
            form.Log(message);
        }

        public string GetInput(string prompt)
        {
            throw new System.NotImplementedException();
        }

        public void ShowResult(string result)
        {
            form.ShowResult(result);
        }

        public void Start()
        {
            Application.Run(form);
        }
    }

}
