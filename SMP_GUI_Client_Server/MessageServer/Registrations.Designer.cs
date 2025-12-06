namespace SMPServer
{
    partial class Registrations
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
            this.textBoxRegistrations = new System.Windows.Forms.TextBox();
            this.radioButtonUserID = new System.Windows.Forms.RadioButton();
            this.radioButtonUserIDPass = new System.Windows.Forms.RadioButton();
            this.buttonShowRegistrations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxRegistrations
            // 
            this.textBoxRegistrations.Location = new System.Drawing.Point(12, 11);
            this.textBoxRegistrations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRegistrations.Multiline = true;
            this.textBoxRegistrations.Name = "textBoxRegistrations";
            this.textBoxRegistrations.Size = new System.Drawing.Size(333, 269);
            this.textBoxRegistrations.TabIndex = 7;
            // 
            // radioButtonUserID
            // 
            this.radioButtonUserID.AutoSize = true;
            this.radioButtonUserID.Location = new System.Drawing.Point(37, 300);
            this.radioButtonUserID.Name = "radioButtonUserID";
            this.radioButtonUserID.Size = new System.Drawing.Size(80, 20);
            this.radioButtonUserID.TabIndex = 8;
            this.radioButtonUserID.TabStop = true;
            this.radioButtonUserID.Text = "User IDs";
            this.radioButtonUserID.UseVisualStyleBackColor = true;
            // 
            // radioButtonUserIDPass
            // 
            this.radioButtonUserIDPass.AutoSize = true;
            this.radioButtonUserIDPass.Location = new System.Drawing.Point(169, 300);
            this.radioButtonUserIDPass.Name = "radioButtonUserIDPass";
            this.radioButtonUserIDPass.Size = new System.Drawing.Size(176, 20);
            this.radioButtonUserIDPass.TabIndex = 9;
            this.radioButtonUserIDPass.TabStop = true;
            this.radioButtonUserIDPass.Text = "User IDs and Passwords";
            this.radioButtonUserIDPass.UseVisualStyleBackColor = true;
            // 
            // buttonShowRegistrations
            // 
            this.buttonShowRegistrations.Location = new System.Drawing.Point(63, 326);
            this.buttonShowRegistrations.Name = "buttonShowRegistrations";
            this.buttonShowRegistrations.Size = new System.Drawing.Size(223, 29);
            this.buttonShowRegistrations.TabIndex = 10;
            this.buttonShowRegistrations.Text = "Show Registrations";
            this.buttonShowRegistrations.UseVisualStyleBackColor = true;
            this.buttonShowRegistrations.Click += new System.EventHandler(this.button1_Click);
            // 
            // Registrations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 450);
            this.Controls.Add(this.buttonShowRegistrations);
            this.Controls.Add(this.radioButtonUserIDPass);
            this.Controls.Add(this.radioButtonUserID);
            this.Controls.Add(this.textBoxRegistrations);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Registrations";
            this.ShowIcon = false;
            this.Text = "Registrations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRegistrations;
        private System.Windows.Forms.RadioButton radioButtonUserID;
        private System.Windows.Forms.RadioButton radioButtonUserIDPass;
        private System.Windows.Forms.Button buttonShowRegistrations;
    }
}