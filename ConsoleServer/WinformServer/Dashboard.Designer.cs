namespace WinformServer
{
    partial class Dashboard
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
            this.btnServerStatus = new System.Windows.Forms.Button();
            this.btnListUsers = new System.Windows.Forms.Button();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtBroadcast = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDBUsers = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(416, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "מנהל שרת צאט";
            // 
            // btnServerStatus
            // 
            this.btnServerStatus.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnServerStatus.Location = new System.Drawing.Point(87, 76);
            this.btnServerStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnServerStatus.Name = "btnServerStatus";
            this.btnServerStatus.Size = new System.Drawing.Size(131, 57);
            this.btnServerStatus.TabIndex = 20;
            this.btnServerStatus.Text = "סטטוס שרת";
            this.btnServerStatus.UseVisualStyleBackColor = true;
            this.btnServerStatus.Click += new System.EventHandler(this.btnServerStatus_Click);
            // 
            // btnListUsers
            // 
            this.btnListUsers.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnListUsers.Location = new System.Drawing.Point(269, 76);
            this.btnListUsers.Margin = new System.Windows.Forms.Padding(4);
            this.btnListUsers.Name = "btnListUsers";
            this.btnListUsers.Size = new System.Drawing.Size(169, 57);
            this.btnListUsers.TabIndex = 21;
            this.btnListUsers.Text = "משתמשים מחוברים";
            this.btnListUsers.UseVisualStyleBackColor = true;
            this.btnListUsers.Click += new System.EventHandler(this.btnListUsers_Click);
            // 
            // lstStatus
            // 
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.ItemHeight = 19;
            this.lstStatus.Location = new System.Drawing.Point(87, 168);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(850, 327);
            this.lstStatus.TabIndex = 23;
            this.lstStatus.SelectedIndexChanged += new System.EventHandler(this.lstStatus_SelectedIndexChanged_1);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnClear.Location = new System.Drawing.Point(885, 76);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(52, 57);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "נקה";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtBroadcast
            // 
            this.txtBroadcast.Location = new System.Drawing.Point(87, 533);
            this.txtBroadcast.Name = "txtBroadcast";
            this.txtBroadcast.Size = new System.Drawing.Size(850, 26);
            this.txtBroadcast.TabIndex = 25;
            this.txtBroadcast.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(852, 512);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "שלח לכולם";
            // 
            // btnDBUsers
            // 
            this.btnDBUsers.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnDBUsers.Location = new System.Drawing.Point(493, 76);
            this.btnDBUsers.Margin = new System.Windows.Forms.Padding(4);
            this.btnDBUsers.Name = "btnDBUsers";
            this.btnDBUsers.Size = new System.Drawing.Size(144, 57);
            this.btnDBUsers.TabIndex = 27;
            this.btnDBUsers.Text = "משתמשים קיימים";
            this.btnDBUsers.UseVisualStyleBackColor = true;
            this.btnDBUsers.Click += new System.EventHandler(this.btnDBUsers_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnTestConnection.Location = new System.Drawing.Point(770, 76);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(103, 57);
            this.btnTestConnection.TabIndex = 28;
            this.btnTestConnection.Text = "בדיקת תקינות חיבור לDB";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 663);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnDBUsers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBroadcast);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lstStatus);
            this.Controls.Add(this.btnListUsers);
            this.Controls.Add(this.btnServerStatus);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.Text = "מנהל שרת צאט";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnServerStatus;
        private System.Windows.Forms.Button btnListUsers;
        private System.Windows.Forms.ListBox lstStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtBroadcast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDBUsers;
        private System.Windows.Forms.Button btnTestConnection;
    }
}

