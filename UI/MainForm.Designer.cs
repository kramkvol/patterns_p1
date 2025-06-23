using System.Windows.Forms;
using System.Drawing;

namespace CiphersWithPatterns
{
    partial class MainForm
    {
        private TextBox txtMessage;
        private TextBox txtKey1;
        private TextBox txtKey2;
        private ComboBox cmbCipherType;
        private Button btnEncrypt;
        private Button btnDecrypt;
        public TextBox txtLog;

        private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtKey1 = new System.Windows.Forms.TextBox();
            this.txtKey2 = new System.Windows.Forms.TextBox();
            this.cmbCipherType = new System.Windows.Forms.ComboBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(20, 20);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(100, 20);
            this.txtMessage.TabIndex = 0;
            // 
            // txtKey1
            // 
            this.txtKey1.Location = new System.Drawing.Point(20, 50);
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.Size = new System.Drawing.Size(100, 20);
            this.txtKey1.TabIndex = 1;
            // 
            // txtKey2
            // 
            this.txtKey2.Location = new System.Drawing.Point(20, 80);
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.Size = new System.Drawing.Size(100, 20);
            this.txtKey2.TabIndex = 2;
            // 
            // cmbCipherType
            // 
            this.cmbCipherType.Items.AddRange(new object[] {
            "Playfair",
            "Vigenere",
            "Winston"});
            this.cmbCipherType.Location = new System.Drawing.Point(20, 110);
            this.cmbCipherType.Name = "cmbCipherType";
            this.cmbCipherType.Size = new System.Drawing.Size(121, 21);
            this.cmbCipherType.TabIndex = 3;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(20, 140);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(120, 140);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtLog
            // 
            this.txtLog.AccessibleName = "txtLog";
            this.txtLog.Location = new System.Drawing.Point(433, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(398, 493);
            this.txtLog.TabIndex = 7;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(843, 517);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtKey1);
            this.Controls.Add(this.txtKey2);
            this.Controls.Add(this.cmbCipherType);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.txtLog);
            this.Name = "MainForm";
            this.Text = "Cipher UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
