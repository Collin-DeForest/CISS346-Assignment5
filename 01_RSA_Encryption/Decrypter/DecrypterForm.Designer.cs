namespace Decrypter
{
    partial class DecrypterForm
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
            this.textBoxtDecryptedMessage = new System.Windows.Forms.TextBox();
            this.buttonDecryptMessage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMessageFile = new System.Windows.Forms.TextBox();
            this.textBoxPrivateKeyFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxtDecryptedMessage
            // 
            this.textBoxtDecryptedMessage.Location = new System.Drawing.Point(12, 140);
            this.textBoxtDecryptedMessage.Multiline = true;
            this.textBoxtDecryptedMessage.Name = "textBoxtDecryptedMessage";
            this.textBoxtDecryptedMessage.Size = new System.Drawing.Size(527, 200);
            this.textBoxtDecryptedMessage.TabIndex = 5;
            // 
            // buttonDecryptMessage
            // 
            this.buttonDecryptMessage.Location = new System.Drawing.Point(12, 362);
            this.buttonDecryptMessage.Name = "buttonDecryptMessage";
            this.buttonDecryptMessage.Size = new System.Drawing.Size(527, 49);
            this.buttonDecryptMessage.TabIndex = 4;
            this.buttonDecryptMessage.Text = "Decrypt Message";
            this.buttonDecryptMessage.UseVisualStyleBackColor = true;
            this.buttonDecryptMessage.Click += new System.EventHandler(this.buttonDecryptMessage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Encrypted Message File";
            // 
            // textBoxMessageFile
            // 
            this.textBoxMessageFile.Location = new System.Drawing.Point(19, 74);
            this.textBoxMessageFile.Name = "textBoxMessageFile";
            this.textBoxMessageFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxMessageFile.Size = new System.Drawing.Size(520, 26);
            this.textBoxMessageFile.TabIndex = 7;
            this.textBoxMessageFile.Text = "C:\\Code\\CISS346\\08_CSharp_Cryptography\\01_RSA_Encryption\\Message.txt";
            // 
            // textBoxPrivateKeyFile
            // 
            this.textBoxPrivateKeyFile.Location = new System.Drawing.Point(137, 6);
            this.textBoxPrivateKeyFile.Name = "textBoxPrivateKeyFile";
            this.textBoxPrivateKeyFile.Size = new System.Drawing.Size(400, 26);
            this.textBoxPrivateKeyFile.TabIndex = 9;
            this.textBoxPrivateKeyFile.Text = "Private.key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Private Key File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Decrypted Message";
            // 
            // DecrypterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 431);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPrivateKeyFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMessageFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxtDecryptedMessage);
            this.Controls.Add(this.buttonDecryptMessage);
            this.Name = "DecrypterForm";
            this.ShowIcon = false;
            this.Text = "Decrypter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxtDecryptedMessage;
        private System.Windows.Forms.Button buttonDecryptMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMessageFile;
        private System.Windows.Forms.TextBox textBoxPrivateKeyFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

