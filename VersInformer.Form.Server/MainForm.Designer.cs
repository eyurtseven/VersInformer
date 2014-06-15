namespace VersInformer.Form.Server
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.leftSidePanel = new System.Windows.Forms.Panel();
            this.btnVersAlindi = new System.Windows.Forms.Button();
            this.btnVersTesteHazir = new System.Windows.Forms.Button();
            this.btnVersAlinacak = new System.Windows.Forms.Button();
            this.btnVersAliniyor = new System.Windows.Forms.Button();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.chatBoxHost = new System.Windows.Forms.Integration.ElementHost();
            this.chatBox = new VersInformer.WPF.Controls.ChatBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtVersionNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCheckinStatus = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.leftSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(13, 117);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(202, 35);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(13, 31);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(202, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "Server User";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(13, 81);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(202, 20);
            this.txtIp.TabIndex = 2;
            this.txtIp.Text = "localhost";
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel.Controls.Add(this.pictureBox1);
            this.headerPanel.Location = new System.Drawing.Point(-2, -3);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(962, 54);
            this.headerPanel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VersInformer.Form.Server.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(14, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // leftSidePanel
            // 
            this.leftSidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftSidePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.leftSidePanel.Controls.Add(this.button1);
            this.leftSidePanel.Controls.Add(this.label5);
            this.leftSidePanel.Controls.Add(this.txtVersionNo);
            this.leftSidePanel.Controls.Add(this.label4);
            this.leftSidePanel.Controls.Add(this.comboBox1);
            this.leftSidePanel.Controls.Add(this.btnVersAlindi);
            this.leftSidePanel.Controls.Add(this.btnVersTesteHazir);
            this.leftSidePanel.Controls.Add(this.btnVersAlinacak);
            this.leftSidePanel.Controls.Add(this.btnVersAliniyor);
            this.leftSidePanel.Controls.Add(this.lblServerStatus);
            this.leftSidePanel.Controls.Add(this.label1);
            this.leftSidePanel.Controls.Add(this.label3);
            this.leftSidePanel.Controls.Add(this.label2);
            this.leftSidePanel.Controls.Add(this.txtUserName);
            this.leftSidePanel.Controls.Add(this.txtIp);
            this.leftSidePanel.Controls.Add(this.btnConnect);
            this.leftSidePanel.Location = new System.Drawing.Point(-1, 51);
            this.leftSidePanel.Name = "leftSidePanel";
            this.leftSidePanel.Size = new System.Drawing.Size(232, 511);
            this.leftSidePanel.TabIndex = 4;
            // 
            // btnVersAlindi
            // 
            this.btnVersAlindi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVersAlindi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVersAlindi.ForeColor = System.Drawing.Color.White;
            this.btnVersAlindi.Location = new System.Drawing.Point(16, 419);
            this.btnVersAlindi.Name = "btnVersAlindi";
            this.btnVersAlindi.Size = new System.Drawing.Size(202, 35);
            this.btnVersAlindi.TabIndex = 14;
            this.btnVersAlindi.Text = "Versiyon Alındı";
            this.btnVersAlindi.UseVisualStyleBackColor = true;
            this.btnVersAlindi.Click += new System.EventHandler(this.btnVersAlindi_Click);
            // 
            // btnVersTesteHazir
            // 
            this.btnVersTesteHazir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVersTesteHazir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVersTesteHazir.ForeColor = System.Drawing.Color.White;
            this.btnVersTesteHazir.Location = new System.Drawing.Point(16, 378);
            this.btnVersTesteHazir.Name = "btnVersTesteHazir";
            this.btnVersTesteHazir.Size = new System.Drawing.Size(202, 35);
            this.btnVersTesteHazir.TabIndex = 13;
            this.btnVersTesteHazir.Text = "Versiyon Teste Hazır";
            this.btnVersTesteHazir.UseVisualStyleBackColor = true;
            this.btnVersTesteHazir.Click += new System.EventHandler(this.btnVersTesteHazir_Click);
            // 
            // btnVersAlinacak
            // 
            this.btnVersAlinacak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVersAlinacak.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVersAlinacak.ForeColor = System.Drawing.Color.White;
            this.btnVersAlinacak.Location = new System.Drawing.Point(16, 337);
            this.btnVersAlinacak.Name = "btnVersAlinacak";
            this.btnVersAlinacak.Size = new System.Drawing.Size(202, 35);
            this.btnVersAlinacak.TabIndex = 12;
            this.btnVersAlinacak.Text = "Versiyon Alınacak";
            this.btnVersAlinacak.UseVisualStyleBackColor = true;
            this.btnVersAlinacak.Click += new System.EventHandler(this.btnVersAlinacak_Click);
            // 
            // btnVersAliniyor
            // 
            this.btnVersAliniyor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVersAliniyor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVersAliniyor.ForeColor = System.Drawing.Color.White;
            this.btnVersAliniyor.Location = new System.Drawing.Point(16, 296);
            this.btnVersAliniyor.Name = "btnVersAliniyor";
            this.btnVersAliniyor.Size = new System.Drawing.Size(202, 35);
            this.btnVersAliniyor.TabIndex = 11;
            this.btnVersAliniyor.Text = "Versiyon Alınıyor";
            this.btnVersAliniyor.UseVisualStyleBackColor = true;
            this.btnVersAliniyor.Click += new System.EventHandler(this.btnVersAliniyor_Click);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblServerStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblServerStatus.Location = new System.Drawing.Point(132, 166);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(94, 13);
            this.lblServerStatus.TabIndex = 6;
            this.lblServerStatus.Text = "Disconnected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Connection Status : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "User";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(237, 508);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(618, 46);
            this.txtMessage.TabIndex = 6;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(861, 508);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 46);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "GÖNDER";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // chatBoxHost
            // 
            this.chatBoxHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBoxHost.Location = new System.Drawing.Point(237, 57);
            this.chatBoxHost.Name = "chatBoxHost";
            this.chatBoxHost.Size = new System.Drawing.Size(527, 445);
            this.chatBoxHost.TabIndex = 8;
            this.chatBoxHost.Child = this.chatBox;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(172, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "için";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TEST",
            "UAT",
            "LIVE"});
            this.comboBox1.Location = new System.Drawing.Point(16, 259);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // txtVersionNo
            // 
            this.txtVersionNo.Location = new System.Drawing.Point(111, 457);
            this.txtVersionNo.Name = "txtVersionNo";
            this.txtVersionNo.Size = new System.Drawing.Size(107, 20);
            this.txtVersionNo.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Versiyon No :";
            // 
            // lbCheckinStatus
            // 
            this.lbCheckinStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCheckinStatus.FormattingEnabled = true;
            this.lbCheckinStatus.Location = new System.Drawing.Point(770, 57);
            this.lbCheckinStatus.Name = "lbCheckinStatus";
            this.lbCheckinStatus.Size = new System.Drawing.Size(181, 446);
            this.lbCheckinStatus.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(16, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 35);
            this.button1.TabIndex = 19;
            this.button1.Text = "Check-in Status : Serbest";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 561);
            this.Controls.Add(this.lbCheckinStatus);
            this.Controls.Add(this.chatBoxHost);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.leftSidePanel);
            this.Controls.Add(this.headerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "VersInformer Server";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.leftSidePanel.ResumeLayout(false);
            this.leftSidePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel leftSidePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnVersAlindi;
        private System.Windows.Forms.Button btnVersTesteHazir;
        private System.Windows.Forms.Button btnVersAlinacak;
        private System.Windows.Forms.Button btnVersAliniyor;
        private System.Windows.Forms.Integration.ElementHost chatBoxHost;
        private WPF.Controls.ChatBox chatBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVersionNo;
        private System.Windows.Forms.ListBox lbCheckinStatus;
        private System.Windows.Forms.Button button1;
    }
}

