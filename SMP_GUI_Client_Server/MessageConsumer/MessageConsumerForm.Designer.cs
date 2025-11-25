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
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxApplicationPortNumber);
            this.groupBox1.Controls.Add(this.textBoxServerIPAddress);
            this.groupBox1.Location = new System.Drawing.Point(25, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 85);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Application Port Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server IP Address";
            // 
            // textBoxApplicationPortNumber
            // 
            this.textBoxApplicationPortNumber.Location = new System.Drawing.Point(546, 37);
            this.textBoxApplicationPortNumber.Name = "textBoxApplicationPortNumber";
            this.textBoxApplicationPortNumber.Size = new System.Drawing.Size(89, 26);
            this.textBoxApplicationPortNumber.TabIndex = 1;
            this.textBoxApplicationPortNumber.Text = "50400";
            this.textBoxApplicationPortNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxServerIPAddress
            // 
            this.textBoxServerIPAddress.Location = new System.Drawing.Point(160, 37);
            this.textBoxServerIPAddress.Name = "textBoxServerIPAddress";
            this.textBoxServerIPAddress.Size = new System.Drawing.Size(162, 26);
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
            this.groupBox2.Location = new System.Drawing.Point(25, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 323);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message";
            // 
            // buttonGetMessage
            // 
            this.buttonGetMessage.Location = new System.Drawing.Point(190, 270);
            this.buttonGetMessage.Name = "buttonGetMessage";
            this.buttonGetMessage.Size = new System.Drawing.Size(462, 47);
            this.buttonGetMessage.TabIndex = 5;
            this.buttonGetMessage.Text = "Get Message";
            this.buttonGetMessage.UseVisualStyleBackColor = true;
            this.buttonGetMessage.Click += new System.EventHandler(this.buttonGetMessage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Message Content";
            // 
            // textBoxMessageContent
            // 
            this.textBoxMessageContent.Location = new System.Drawing.Point(188, 77);
            this.textBoxMessageContent.Multiline = true;
            this.textBoxMessageContent.Name = "textBoxMessageContent";
            this.textBoxMessageContent.ReadOnly = true;
            this.textBoxMessageContent.Size = new System.Drawing.Size(464, 175);
            this.textBoxMessageContent.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonPriorityHigh);
            this.groupBox3.Controls.Add(this.radioButtonPriorityMedium);
            this.groupBox3.Controls.Add(this.radioButtonPriorityLow);
            this.groupBox3.Location = new System.Drawing.Point(30, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 212);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Priority";
            // 
            // radioButtonPriorityHigh
            // 
            this.radioButtonPriorityHigh.AutoSize = true;
            this.radioButtonPriorityHigh.Location = new System.Drawing.Point(10, 147);
            this.radioButtonPriorityHigh.Name = "radioButtonPriorityHigh";
            this.radioButtonPriorityHigh.Size = new System.Drawing.Size(67, 24);
            this.radioButtonPriorityHigh.TabIndex = 2;
            this.radioButtonPriorityHigh.Text = "High";
            this.radioButtonPriorityHigh.UseVisualStyleBackColor = true;
            // 
            // radioButtonPriorityMedium
            // 
            this.radioButtonPriorityMedium.AutoSize = true;
            this.radioButtonPriorityMedium.Location = new System.Drawing.Point(10, 92);
            this.radioButtonPriorityMedium.Name = "radioButtonPriorityMedium";
            this.radioButtonPriorityMedium.Size = new System.Drawing.Size(90, 24);
            this.radioButtonPriorityMedium.TabIndex = 1;
            this.radioButtonPriorityMedium.Text = "Medium";
            this.radioButtonPriorityMedium.UseVisualStyleBackColor = true;
            // 
            // radioButtonPriorityLow
            // 
            this.radioButtonPriorityLow.AutoSize = true;
            this.radioButtonPriorityLow.Checked = true;
            this.radioButtonPriorityLow.Location = new System.Drawing.Point(10, 37);
            this.radioButtonPriorityLow.Name = "radioButtonPriorityLow";
            this.radioButtonPriorityLow.Size = new System.Drawing.Size(63, 24);
            this.radioButtonPriorityLow.TabIndex = 0;
            this.radioButtonPriorityLow.TabStop = true;
            this.radioButtonPriorityLow.Text = "Low";
            this.radioButtonPriorityLow.UseVisualStyleBackColor = true;
            // 
            // MessageConsumerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 467);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
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
    }
}

