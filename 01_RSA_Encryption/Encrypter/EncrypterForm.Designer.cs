namespace Encrypter
{
    partial class EncrypterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonEncryptMessage = new System.Windows.Forms.Button();
            this.textBoxtEncryptedMessage = new System.Windows.Forms.TextBox();
            this.textBoxEncryptedMessageFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPublicKeyFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(12, 142);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMessage.Size = new System.Drawing.Size(520, 156);
            this.textBoxMessage.TabIndex = 1;
            this.textBoxMessage.Text = "Hello, world!";
            // 
            // buttonEncryptMessage
            // 
            this.buttonEncryptMessage.Location = new System.Drawing.Point(12, 527);
            this.buttonEncryptMessage.Name = "buttonEncryptMessage";
            this.buttonEncryptMessage.Size = new System.Drawing.Size(520, 49);
            this.buttonEncryptMessage.TabIndex = 2;
            this.buttonEncryptMessage.Text = "Encrypt Message";
            this.buttonEncryptMessage.UseVisualStyleBackColor = true;
            this.buttonEncryptMessage.Click += new System.EventHandler(this.buttonEncryptMessage_Click);
            // 
            // textBoxtEncryptedMessage
            // 
            this.textBoxtEncryptedMessage.Location = new System.Drawing.Point(12, 336);
            this.textBoxtEncryptedMessage.Multiline = true;
            this.textBoxtEncryptedMessage.Name = "textBoxtEncryptedMessage";
            this.textBoxtEncryptedMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxtEncryptedMessage.Size = new System.Drawing.Size(520, 174);
            this.textBoxtEncryptedMessage.TabIndex = 3;
            // 
            // textBoxEncryptedMessageFile
            // 
            this.textBoxEncryptedMessageFile.Location = new System.Drawing.Point(16, 78);
            this.textBoxEncryptedMessageFile.Name = "textBoxEncryptedMessageFile";
            this.textBoxEncryptedMessageFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxEncryptedMessageFile.Size = new System.Drawing.Size(516, 26);
            this.textBoxEncryptedMessageFile.TabIndex = 5;
            this.textBoxEncryptedMessageFile.Text = "C:\\Code\\CISS346\\08_CSharp_Cryptography\\01_RSA_Encryption\\Message.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encrypted Message File";
            // 
            // textBoxPublicKeyFile
            // 
            this.textBoxPublicKeyFile.Location = new System.Drawing.Point(132, 12);
            this.textBoxPublicKeyFile.Name = "textBoxPublicKeyFile";
            this.textBoxPublicKeyFile.Size = new System.Drawing.Size(400, 26);
            this.textBoxPublicKeyFile.TabIndex = 7;
            this.textBoxPublicKeyFile.Text = "Public.key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Public Key File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Encrypted Message";
            // 
            // EncrypterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 591);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPublicKeyFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxEncryptedMessageFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxtEncryptedMessage);
            this.Controls.Add(this.buttonEncryptMessage);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.label1);
            this.Name = "EncrypterForm";
            this.ShowIcon = false;
            this.Text = "Encrypter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonEncryptMessage;
        private System.Windows.Forms.TextBox textBoxtEncryptedMessage;
        private System.Windows.Forms.TextBox textBoxEncryptedMessageFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPublicKeyFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

