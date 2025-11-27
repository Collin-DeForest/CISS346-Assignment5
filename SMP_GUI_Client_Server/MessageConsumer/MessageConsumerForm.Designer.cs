namespace SMPClientConsumer
{
    partial class MessageConsumerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxApplicationPortNumber = new System.Windows.Forms.TextBox();
            this.textBoxServerIPAddress = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonGetMessage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMessageContent = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonPriorityHigh = new System.Windows.Forms.RadioButton();
            this.radioButtonPriorityMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonPriorityLow = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.textBoxUserID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxApplicationPortNumber);
            this.groupBox1.Controls.Add(this.textBoxServerIPAddress);
            this.groupBox1.Location = new System.Drawing.Point(22, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(598, 112);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(376, 69);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(189, 22);
            this.textBoxPassword.TabIndex = 8;
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(142, 72);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(144, 22);
            this.textBoxUserID.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "User ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Application Port Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server IP Address";
            // 
            // textBoxApplicationPortNumber
            // 
            this.textBoxApplicationPortNumber.Location = new System.Drawing.Point(485, 30);
            this.textBoxApplicationPortNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxApplicationPortNumber.Name = "textBoxApplicationPortNumber";
            this.textBoxApplicationPortNumber.Size = new System.Drawing.Size(80, 22);
            this.textBoxApplicationPortNumber.TabIndex = 1;
            this.textBoxApplicationPortNumber.Text = "50400";
            this.textBoxApplicationPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxServerIPAddress
            // 
            this.textBoxServerIPAddress.Location = new System.Drawing.Point(142, 30);
            this.textBoxServerIPAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxServerIPAddress.Name = "textBoxServerIPAddress";
            this.textBoxServerIPAddress.Size = new System.Drawing.Size(144, 22);
            this.textBoxServerIPAddress.TabIndex = 0;
            this.textBoxServerIPAddress.Text = "127.0.0.1";
            this.textBoxServerIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonGetMessage);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxMessageContent);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(22, 195);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(597, 258);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message";
            // 
            // buttonGetMessage
            // 
            this.buttonGetMessage.Location = new System.Drawing.Point(169, 216);
            this.buttonGetMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGetMessage.Name = "buttonGetMessage";
            this.buttonGetMessage.Size = new System.Drawing.Size(411, 38);
            this.buttonGetMessage.TabIndex = 5;
            this.buttonGetMessage.Text = "Get Message";
            this.buttonGetMessage.UseVisualStyleBackColor = true;
            this.buttonGetMessage.Click += new System.EventHandler(this.buttonGetMessage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Message Content";
            // 
            // textBoxMessageContent
            // 
            this.textBoxMessageContent.Location = new System.Drawing.Point(167, 62);
            this.textBoxMessageContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMessageContent.Multiline = true;
            this.textBoxMessageContent.Name = "textBoxMessageContent";
            this.textBoxMessageContent.ReadOnly = true;
            this.textBoxMessageContent.Size = new System.Drawing.Size(413, 141);
            this.textBoxMessageContent.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonPriorityHigh);
            this.groupBox3.Controls.Add(this.radioButtonPriorityMedium);
            this.groupBox3.Controls.Add(this.radioButtonPriorityLow);
            this.groupBox3.Location = new System.Drawing.Point(27, 33);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(124, 170);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Priority";
            // 
            // radioButtonPriorityHigh
            // 
            this.radioButtonPriorityHigh.AutoSize = true;
            this.radioButtonPriorityHigh.Location = new System.Drawing.Point(9, 118);
            this.radioButtonPriorityHigh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPriorityHigh.Name = "radioButtonPriorityHigh";
            this.radioButtonPriorityHigh.Size = new System.Drawing.Size(56, 20);
            this.radioButtonPriorityHigh.TabIndex = 2;
            this.radioButtonPriorityHigh.Text = "High";
            this.radioButtonPriorityHigh.UseVisualStyleBackColor = true;
            // 
            // radioButtonPriorityMedium
            // 
            this.radioButtonPriorityMedium.AutoSize = true;
            this.radioButtonPriorityMedium.Location = new System.Drawing.Point(9, 74);
            this.radioButtonPriorityMedium.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPriorityMedium.Name = "radioButtonPriorityMedium";
            this.radioButtonPriorityMedium.Size = new System.Drawing.Size(76, 20);
            this.radioButtonPriorityMedium.TabIndex = 1;
            this.radioButtonPriorityMedium.Text = "Medium";
            this.radioButtonPriorityMedium.UseVisualStyleBackColor = true;
            // 
            // radioButtonPriorityLow
            // 
            this.radioButtonPriorityLow.AutoSize = true;
            this.radioButtonPriorityLow.Checked = true;
            this.radioButtonPriorityLow.Location = new System.Drawing.Point(9, 30);
            this.radioButtonPriorityLow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPriorityLow.Name = "radioButtonPriorityLow";
            this.radioButtonPriorityLow.Size = new System.Drawing.Size(52, 20);
            this.radioButtonPriorityLow.TabIndex = 0;
            this.radioButtonPriorityLow.TabStop = true;
            this.radioButtonPriorityLow.Text = "Low";
            this.radioButtonPriorityLow.UseVisualStyleBackColor = true;
            // 
            // MessageConsumerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageConsumerForm";
            this.ShowIcon = false;
            this.Text = "Message Consumer Version 1.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxApplicationPortNumber;
        private System.Windows.Forms.TextBox textBoxServerIPAddress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonGetMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMessageContent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonPriorityHigh;
        private System.Windows.Forms.RadioButton radioButtonPriorityMedium;
        private System.Windows.Forms.RadioButton radioButtonPriorityLow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserID;
    }
}

