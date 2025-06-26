using System.Windows.Forms;
using System.Drawing;

namespace CiphersWithPatterns
{
    partial class MainForm
    {
        private TextBox txtMessage;
        private TextBox txtKey1;
        private TextBox txtKey2;
        private ComboBox cmbCipher;
        private Button btnOK;
        public TextBox txtLog;

        private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtKey1 = new System.Windows.Forms.TextBox();
            this.txtKey2 = new System.Windows.Forms.TextBox();
            this.cmbCipher = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelKey1 = new System.Windows.Forms.Label();
            this.labelKey2 = new System.Windows.Forms.Label();
            this.labelCipher = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.labelRes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMessage.Location = new System.Drawing.Point(20, 109);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(394, 53);
            this.txtMessage.TabIndex = 4;
            // 
            // txtKey1
            // 
            this.txtKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtKey1.Location = new System.Drawing.Point(20, 202);
            this.txtKey1.Multiline = true;
            this.txtKey1.Name = "txtKey1";
            this.txtKey1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKey1.Size = new System.Drawing.Size(394, 53);
            this.txtKey1.TabIndex = 4;
            // 
            // txtKey2
            // 
            this.txtKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtKey2.Location = new System.Drawing.Point(20, 294);
            this.txtKey2.Multiline = true;
            this.txtKey2.Name = "txtKey2";
            this.txtKey2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKey2.Size = new System.Drawing.Size(394, 53);
            this.txtKey2.TabIndex = 4;
            // 
            // cmbCipher
            // 
            this.cmbCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCipher.Items.AddRange(new object[] {
            "Playfair",
            "Winston",
            "Vigenere"});
            this.cmbCipher.Location = new System.Drawing.Point(20, 37);
            this.cmbCipher.Name = "cmbCipher";
            this.cmbCipher.Size = new System.Drawing.Size(394, 32);
            this.cmbCipher.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(20, 469);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 36);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtLog
            // 
            this.txtLog.AccessibleName = "txtLog";
            this.txtLog.Location = new System.Drawing.Point(433, 202);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(398, 303);
            this.txtLog.TabIndex = 7;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMessage.Location = new System.Drawing.Point(16, 82);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(97, 24);
            this.labelMessage.TabIndex = 8;
            this.labelMessage.Text = "Message: ";
            // 
            // labelKey1
            // 
            this.labelKey1.AutoSize = true;
            this.labelKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKey1.Location = new System.Drawing.Point(16, 175);
            this.labelKey1.Name = "labelKey1";
            this.labelKey1.Size = new System.Drawing.Size(89, 24);
            this.labelKey1.TabIndex = 9;
            this.labelKey1.Text = "First key: ";
            // 
            // labelKey2
            // 
            this.labelKey2.AutoSize = true;
            this.labelKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKey2.Location = new System.Drawing.Point(16, 267);
            this.labelKey2.Name = "labelKey2";
            this.labelKey2.Size = new System.Drawing.Size(120, 24);
            this.labelKey2.TabIndex = 10;
            this.labelKey2.Text = "Second key: ";
            // 
            // labelCipher
            // 
            this.labelCipher.AutoSize = true;
            this.labelCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCipher.Location = new System.Drawing.Point(16, 10);
            this.labelCipher.Name = "labelCipher";
            this.labelCipher.Size = new System.Drawing.Size(76, 24);
            this.labelCipher.TabIndex = 11;
            this.labelCipher.Text = "Cipher: ";
            // 
            // textBox1
            // 
            this.textBox1.AccessibleName = "txtLog";
            this.textBox1.Location = new System.Drawing.Point(433, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(398, 125);
            this.textBox1.TabIndex = 12;
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLog.Location = new System.Drawing.Point(429, 175);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(47, 24);
            this.labelLog.TabIndex = 13;
            this.labelLog.Text = "Log:";
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRes.Location = new System.Drawing.Point(429, 9);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(81, 24);
            this.labelRes.TabIndex = 14;
            this.labelRes.Text = "Results: ";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(843, 517);
            this.Controls.Add(this.labelRes);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelCipher);
            this.Controls.Add(this.labelKey2);
            this.Controls.Add(this.labelKey1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtKey1);
            this.Controls.Add(this.txtKey2);
            this.Controls.Add(this.cmbCipher);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtLog);
            this.Name = "MainForm";
            this.Text = "Cipher UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label labelMessage;
        private Label labelKey1;
        private Label labelKey2;
        private Label labelCipher;
        public TextBox textBox1;
        private Label labelLog;
        private Label labelRes;
    }
}
