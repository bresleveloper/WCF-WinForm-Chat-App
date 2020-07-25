﻿namespace WinformClient
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
            this.txtChatInput = new System.Windows.Forms.TextBox();
            this.btnTestFlash = new System.Windows.Forms.Button();
            this.lblChatWith = new System.Windows.Forms.Label();
            this.txtBroadcast = new System.Windows.Forms.TextBox();
            this.lblBroadcast = new System.Windows.Forms.Label();
            this.btnConnectAharon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(519, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "תוכנת התכתבות צ\'אט";
            // 
            // lstChat
            // 
            this.lstChat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lstChat.FormattingEnabled = true;
            this.lstChat.IntegralHeight = false;
            this.lstChat.ItemHeight = 19;
            this.lstChat.Location = new System.Drawing.Point(57, 178);
            this.lstChat.Margin = new System.Windows.Forms.Padding(4);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(854, 403);
            this.lstChat.TabIndex = 18;
            this.lstChat.SelectedIndexChanged += new System.EventHandler(this.lstChat_SelectedIndexChanged);
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
            this.lstUsers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstUsers_MouseClick);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(969, 53);
            this.lblUsers.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(161, 25);
            this.lblUsers.TabIndex = 20;
            this.lblUsers.Text = "רשימת משתתפים";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(622, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "חלון התכתבות";
            // 
            // btnRefreshUsers
            // 
            this.btnRefreshUsers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefreshUsers.Location = new System.Drawing.Point(1155, 41);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Size = new System.Drawing.Size(55, 37);
            this.btnRefreshUsers.TabIndex = 22;
            this.btnRefreshUsers.Text = "רענן";
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
            this.btnConnect.Text = "התחבר לשרת מחדש";
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
            this.lblWelcomeName.Location = new System.Drawing.Point(653, 82);
            this.lblWelcomeName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWelcomeName.Name = "lblWelcomeName";
            this.lblWelcomeName.Size = new System.Drawing.Size(63, 25);
            this.lblWelcomeName.TabIndex = 26;
            this.lblWelcomeName.Text = "שלום ";
            // 
            // lblWelcomeADName
            // 
            this.lblWelcomeADName.AutoSize = true;
            this.lblWelcomeADName.Font = new System.Drawing.Font("Monotype Corsiva", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeADName.Location = new System.Drawing.Point(655, 107);
            this.lblWelcomeADName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWelcomeADName.Name = "lblWelcomeADName";
            this.lblWelcomeADName.Size = new System.Drawing.Size(33, 15);
            this.lblWelcomeADName.TabIndex = 27;
            this.lblWelcomeADName.Text = "שלום ";
            // 
            // txtChatInput
            // 
            this.txtChatInput.Location = new System.Drawing.Point(56, 605);
            this.txtChatInput.Multiline = true;
            this.txtChatInput.Name = "txtChatInput";
            this.txtChatInput.Size = new System.Drawing.Size(855, 68);
            this.txtChatInput.TabIndex = 28;
            this.txtChatInput.TextChanged += new System.EventHandler(this.txtChatInput_TextChanged);
            // 
            // btnTestFlash
            // 
            this.btnTestFlash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTestFlash.Location = new System.Drawing.Point(524, 726);
            this.btnTestFlash.Name = "btnTestFlash";
            this.btnTestFlash.Size = new System.Drawing.Size(144, 37);
            this.btnTestFlash.TabIndex = 29;
            this.btnTestFlash.Text = "test the flash";
            this.btnTestFlash.UseVisualStyleBackColor = true;
            this.btnTestFlash.Click += new System.EventHandler(this.btnTestFlash_Click);
            // 
            // lblChatWith
            // 
            this.lblChatWith.AutoSize = true;
            this.lblChatWith.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatWith.Location = new System.Drawing.Point(53, 156);
            this.lblChatWith.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblChatWith.Name = "lblChatWith";
            this.lblChatWith.Size = new System.Drawing.Size(88, 18);
            this.lblChatWith.TabIndex = 30;
            this.lblChatWith.Text = "מתכתב עם ";
            // 
            // txtBroadcast
            // 
            this.txtBroadcast.Location = new System.Drawing.Point(974, 605);
            this.txtBroadcast.Multiline = true;
            this.txtBroadcast.Name = "txtBroadcast";
            this.txtBroadcast.Size = new System.Drawing.Size(237, 68);
            this.txtBroadcast.TabIndex = 31;
            this.txtBroadcast.TextChanged += new System.EventHandler(this.txtBroadcast_TextChanged);
            // 
            // lblBroadcast
            // 
            this.lblBroadcast.AutoSize = true;
            this.lblBroadcast.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBroadcast.Location = new System.Drawing.Point(1123, 584);
            this.lblBroadcast.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBroadcast.Name = "lblBroadcast";
            this.lblBroadcast.Size = new System.Drawing.Size(88, 18);
            this.lblBroadcast.TabIndex = 32;
            this.lblBroadcast.Text = "כתוב לכולם";
            // 
            // btnConnectAharon
            // 
            this.btnConnectAharon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConnectAharon.Location = new System.Drawing.Point(348, 726);
            this.btnConnectAharon.Name = "btnConnectAharon";
            this.btnConnectAharon.Size = new System.Drawing.Size(144, 37);
            this.btnConnectAharon.TabIndex = 33;
            this.btnConnectAharon.Text = "Connect As Aharon";
            this.btnConnectAharon.UseVisualStyleBackColor = true;
            this.btnConnectAharon.Click += new System.EventHandler(this.btnConnectAharon_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 775);
            this.Controls.Add(this.btnConnectAharon);
            this.Controls.Add(this.lblBroadcast);
            this.Controls.Add(this.txtBroadcast);
            this.Controls.Add(this.lblChatWith);
            this.Controls.Add(this.btnTestFlash);
            this.Controls.Add(this.txtChatInput);
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
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClientForm";
            this.Text = "תוכנת התכתבות צ\'אט";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.TextBox txtChatInput;
        private System.Windows.Forms.Button btnTestFlash;
        private System.Windows.Forms.Label lblChatWith;
        private System.Windows.Forms.TextBox txtBroadcast;
        private System.Windows.Forms.Label lblBroadcast;
        private System.Windows.Forms.Button btnConnectAharon;
    }
}

