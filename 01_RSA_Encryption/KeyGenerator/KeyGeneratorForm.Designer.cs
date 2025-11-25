namespace KeyGenerator
{
    partial class KeyGeneratorForm
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
            this.textBoxtPublicKey = new System.Windows.Forms.TextBox();
            this.buttonGenerateKeys = new System.Windows.Forms.Button();
            this.textBoxPrivateKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxtPublicKey
            // 
            this.textBoxtPublicKey.Location = new System.Drawing.Point(23, 118);
            this.textBoxtPublicKey.Multiline = true;
            this.textBoxtPublicKey.Name = "textBoxtPublicKey";
            this.textBoxtPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxtPublicKey.Size = new System.Drawing.Size(874, 239);
            this.textBoxtPublicKey.TabIndex = 7;
            // 
            // buttonGenerateKeys
            // 
            this.buttonGenerateKeys.Location = new System.Drawing.Point(234, 24);
            this.buttonGenerateKeys.Name = "buttonGenerateKeys";
            this.buttonGenerateKeys.Size = new System.Drawing.Size(389, 49);
            this.buttonGenerateKeys.TabIndex = 6;
            this.buttonGenerateKeys.Text = "Generate Keys";
            this.buttonGenerateKeys.UseVisualStyleBackColor = true;
            this.buttonGenerateKeys.Click += new System.EventHandler(this.buttonGenerateKeys_Click);
            // 
            // textBoxPrivateKey
            // 
            this.textBoxPrivateKey.Location = new System.Drawing.Point(23, 400);
            this.textBoxPrivateKey.Multiline = true;
            this.textBoxPrivateKey.Name = "textBoxPrivateKey";
            this.textBoxPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPrivateKey.Size = new System.Drawing.Size(874, 237);
            this.textBoxPrivateKey.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Public Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Private Key";
            // 
            // KeyGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 649);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPrivateKey);
            this.Controls.Add(this.textBoxtPublicKey);
            this.Controls.Add(this.buttonGenerateKeys);
            this.Name = "KeyGeneratorForm";
            this.ShowIcon = false;
            this.Text = "Key Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxtPublicKey;
        private System.Windows.Forms.Button buttonGenerateKeys;
        private System.Windows.Forms.TextBox textBoxPrivateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

