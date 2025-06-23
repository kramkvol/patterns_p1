using System;
using System.Windows.Forms;


namespace CiphersWithPatterns
{
    public partial class MainForm : Form
    {
        private CipherController controller;

        public MainForm()
        {
            InitializeComponent();
            controller = new CipherController(this);
        }

        public string Message => txtMessage.Text;
        public string Key1 => txtKey1.Text;
        public string Key2 => txtKey2.Text;
        public string TxtLog => txtLog.Text;

        public string CipherType => cmbCipherType.SelectedItem?.ToString();


        public void ShowResult(string result)
        {
             txtLog.Text = result;
        }

        public void Log(string text)
        {
            txtLog.AppendText(text + Environment.NewLine);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            controller.Encrypt();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            controller.Decrypt();
        }
    }
}
