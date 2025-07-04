using Ciphers.Command.commands;
using Ciphers.FactoryMethod;
using Ciphers.Singletone;
using Ciphers.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciphers.UI
{
    public partial class CipherForm : Form
    {
        public CipherForm()
        {
            InitializeComponent();
            UILogger.Initialize(this);
        }

        public void Log(string v)
        {
            textBoxLog.Text += Environment.NewLine + v;
        }

        public void ShowResult(string v)
        {
            textBoxResults.Text += Environment.NewLine + v;
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            textBoxLog.Text = string.Empty;
            textBoxResults.Text = "";

            string abc = "abcdefghijklmnopqrstuvwxyz";
            int rows = 5, cols = 5;
            try
            {
                var createdCipher = CipherFactoryMethod.Create(
                    comboboxCipher.Text,
                    abc,
                    rows,
                    cols,
                    textBoxMessage.Text,
                    textBoxKey1.Text,
                    textBoxKey2.Text
                );
                RunCipher runCipher = new(createdCipher, UILogger.Instance, comboxMode.Text);
                runCipher.Execute();
            }
            catch (Exception ex)
            {
                textBoxLog.Text = $"[ERROR] {ex.GetType} {ex.Message}";
            }
        }
    }
}
