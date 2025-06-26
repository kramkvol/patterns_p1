using System;
using System.Windows.Forms;
using ThePlayfairCipher;


namespace CiphersWithPatterns
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string Message => txtMessage.Text;
        public string Key1 => txtKey1.Text;
        public string Key2 => txtKey2.Text;
        public string TxtLog => txtLog.Text;

        public string CipherType => cmbCipher.SelectedItem?.ToString();


        public void ShowResult(string result)
        {
             txtLog.Text = result;
        }

        public void Log(string text)
        {
            txtLog.AppendText(text + Environment.NewLine);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var logger = new UILogger(this);
            string abc = "abcdefghijklmnopqrstuvwxyz";
            int rows = 5, cols = 5;
            var baseCipher = CipherFactoryMethod.Create(
                cmbCipher.SelectedText,
                abc,
                rows,
                cols,
                txtMessage.Text,
                txtKey1.Text,
                txtKey2.Text
            );
            var cipher = new DebugCipherDecorator(baseCipher);
            
        }
    }
}
