namespace Ciphers.UI
{
    partial class CipherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboboxCipher = new System.Windows.Forms.ComboBox();
            comboxMode = new System.Windows.Forms.ComboBox();
            textBoxKey1 = new System.Windows.Forms.TextBox();
            textBoxKey2 = new System.Windows.Forms.TextBox();
            textBoxMessage = new System.Windows.Forms.TextBox();
            textBoxResults = new System.Windows.Forms.TextBox();
            textBoxLog = new System.Windows.Forms.TextBox();
            buttonGo = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // comboboxCipher
            // 
            comboboxCipher.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboboxCipher.FormattingEnabled = true;
            comboboxCipher.Items.AddRange(new object[] { "Playfair", "Winston", "Vigenere" });
            comboboxCipher.Location = new System.Drawing.Point(16, 12);
            comboboxCipher.Name = "comboboxCipher";
            comboboxCipher.Size = new System.Drawing.Size(392, 31);
            comboboxCipher.TabIndex = 0;
            comboboxCipher.Text = "Select Cipher...";
            // 
            // comboxMode
            // 
            comboxMode.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboxMode.FormattingEnabled = true;
            comboxMode.Items.AddRange(new object[] { "Encrypt", "Decrypt" });
            comboxMode.Location = new System.Drawing.Point(16, 57);
            comboxMode.Name = "comboxMode";
            comboxMode.Size = new System.Drawing.Size(392, 31);
            comboxMode.TabIndex = 1;
            comboxMode.Text = "Select mode...";
            // 
            // textBoxKey1
            // 
            textBoxKey1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxKey1.Location = new System.Drawing.Point(16, 104);
            textBoxKey1.Multiline = true;
            textBoxKey1.Name = "textBoxKey1";
            textBoxKey1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxKey1.Size = new System.Drawing.Size(392, 92);
            textBoxKey1.TabIndex = 2;
            textBoxKey1.Text = "Write First key...";
            // 
            // textBoxKey2
            // 
            textBoxKey2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxKey2.Location = new System.Drawing.Point(16, 202);
            textBoxKey2.Multiline = true;
            textBoxKey2.Name = "textBoxKey2";
            textBoxKey2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxKey2.Size = new System.Drawing.Size(392, 92);
            textBoxKey2.TabIndex = 3;
            textBoxKey2.Text = "Write Second key...";
            // 
            // textBoxMessage
            // 
            textBoxMessage.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxMessage.Location = new System.Drawing.Point(16, 300);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxMessage.Size = new System.Drawing.Size(392, 92);
            textBoxMessage.TabIndex = 4;
            textBoxMessage.Text = "Write Message...";
            // 
            // textBoxResults
            // 
            textBoxResults.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxResults.Location = new System.Drawing.Point(414, 535);
            textBoxResults.Multiline = true;
            textBoxResults.Name = "textBoxResults";
            textBoxResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxResults.Size = new System.Drawing.Size(880, 76);
            textBoxResults.TabIndex = 5;
            textBoxResults.Text = "<Results dispay here>";
            // 
            // textBoxLog
            // 
            textBoxLog.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxLog.Location = new System.Drawing.Point(414, 12);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxLog.Size = new System.Drawing.Size(880, 517);
            textBoxLog.TabIndex = 6;
            textBoxLog.Text = "<Log displays here>";
            // 
            // buttonGo
            // 
            buttonGo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonGo.Location = new System.Drawing.Point(16, 572);
            buttonGo.Name = "buttonGo";
            buttonGo.Size = new System.Drawing.Size(392, 39);
            buttonGo.TabIndex = 9;
            buttonGo.Text = "Go!";
            buttonGo.UseVisualStyleBackColor = true;
            buttonGo.Click += ButtonGo_Click;
            // 
            // CipherForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1306, 623);
            Controls.Add(buttonGo);
            Controls.Add(textBoxResults);
            Controls.Add(textBoxMessage);
            Controls.Add(textBoxKey2);
            Controls.Add(textBoxKey1);
            Controls.Add(comboxMode);
            Controls.Add(comboboxCipher);
            Controls.Add(textBoxLog);
            Name = "CipherForm";
            Text = "CipherForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboboxCipher;
        private System.Windows.Forms.ComboBox comboxMode;
        private System.Windows.Forms.TextBox textBoxKey1;
        private System.Windows.Forms.TextBox textBoxKey2;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.TextBox textBoxResults;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonGo;
    }
}