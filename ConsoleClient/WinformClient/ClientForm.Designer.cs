namespace WinformClient
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefreshUsers = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnMoshe = new System.Windows.Forms.Button();
            this.btnRuth = new System.Windows.Forms.Button();
            this.lblWelcomeName = new System.Windows.Forms.Label();
            this.lblWelcomeADName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(899, 746);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "https://www.bresleveloper.co.il";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(825, 716);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Created just for you by Bresleveloper Digital";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1104, 660);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 117);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(519, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Chat Client";
            // 
            // lstChat
            // 
            this.lstChat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ItemHeight = 19;
            this.lstChat.Location = new System.Drawing.Point(57, 178);
            this.lstChat.Margin = new System.Windows.Forms.Padding(4);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(854, 479);
            this.lstChat.TabIndex = 18;
            // 
            // lstUsers
            // 
            this.lstUsers.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 19;
            this.lstUsers.Location = new System.Drawing.Point(974, 82);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(236, 498);
            this.lstUsers.TabIndex = 19;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(969, 53);
            this.lblUsers.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(131, 25);
            this.lblUsers.TabIndex = 20;
            this.lblUsers.Text = "Available Users";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Chat Window";
            // 
            // btnRefreshUsers
            // 
            this.btnRefreshUsers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefreshUsers.Location = new System.Drawing.Point(1125, 41);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Size = new System.Drawing.Size(85, 37);
            this.btnRefreshUsers.TabIndex = 22;
            this.btnRefreshUsers.Text = "Refresh";
            this.btnRefreshUsers.UseVisualStyleBackColor = true;
            this.btnRefreshUsers.Click += new System.EventHandler(this.btnRefreshUsers_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConnect.Location = new System.Drawing.Point(767, 124);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(144, 37);
            this.btnConnect.TabIndex = 23;
            this.btnConnect.Text = "Connect To Server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnMoshe
            // 
            this.btnMoshe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMoshe.Location = new System.Drawing.Point(12, 726);
            this.btnMoshe.Name = "btnMoshe";
            this.btnMoshe.Size = new System.Drawing.Size(144, 37);
            this.btnMoshe.TabIndex = 24;
            this.btnMoshe.Text = "Connect As Moshe";
            this.btnMoshe.UseVisualStyleBackColor = true;
            this.btnMoshe.Click += new System.EventHandler(this.btnMoshe_Click);
            // 
            // btnRuth
            // 
            this.btnRuth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRuth.Location = new System.Drawing.Point(179, 726);
            this.btnRuth.Name = "btnRuth";
            this.btnRuth.Size = new System.Drawing.Size(144, 37);
            this.btnRuth.TabIndex = 25;
            this.btnRuth.Text = "Connect As Ruth";
            this.btnRuth.UseVisualStyleBackColor = true;
            this.btnRuth.Click += new System.EventHandler(this.btnRuth_Click);
            // 
            // lblWelcomeName
            // 
            this.lblWelcomeName.AutoSize = true;
            this.lblWelcomeName.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeName.Location = new System.Drawing.Point(58, 68);
            this.lblWelcomeName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWelcomeName.Name = "lblWelcomeName";
            this.lblWelcomeName.Size = new System.Drawing.Size(82, 25);
            this.lblWelcomeName.TabIndex = 26;
            this.lblWelcomeName.Text = "Welcome ";
            // 
            // lblWelcomeADName
            // 
            this.lblWelcomeADName.AutoSize = true;
            this.lblWelcomeADName.Font = new System.Drawing.Font("Monotype Corsiva", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeADName.Location = new System.Drawing.Point(58, 93);
            this.lblWelcomeADName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWelcomeADName.Name = "lblWelcomeADName";
            this.lblWelcomeADName.Size = new System.Drawing.Size(50, 15);
            this.lblWelcomeADName.TabIndex = 27;
            this.lblWelcomeADName.Text = "Welcome ";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 775);
            this.Controls.Add(this.lblWelcomeADName);
            this.Controls.Add(this.lblWelcomeName);
            this.Controls.Add(this.btnRuth);
            this.Controls.Add(this.btnMoshe);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRefreshUsers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientForm";
            this.Text = "WinForm Chat Client - by Bresleveloper Digital";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefreshUsers;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnMoshe;
        private System.Windows.Forms.Button btnRuth;
        private System.Windows.Forms.Label lblWelcomeName;
        private System.Windows.Forms.Label lblWelcomeADName;
    }
}

