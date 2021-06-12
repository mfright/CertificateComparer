namespace certificateComparer1
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.btn_SelectKey = new System.Windows.Forms.Button();
            this.btn_SelectServerCertificate = new System.Windows.Forms.Button();
            this.btn_SelectIntermediateCertificate = new System.Windows.Forms.Button();
            this.txtFileSecretKey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblInfo_serverCertificate = new System.Windows.Forms.Label();
            this.txtFileServerCertificate = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblInfo_intermediateCertificate = new System.Windows.Forms.Label();
            this.txtFileIntermediateCertificate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.lblAnswer_key_and_server = new System.Windows.Forms.Label();
            this.lblAnswer_server_and_intermediate = new System.Windows.Forms.Label();
            this.tmrStartCompare = new System.Windows.Forms.Timer(this.components);
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblInfo_rootCertificate = new System.Windows.Forms.Label();
            this.btn_SelectRootCertificate = new System.Windows.Forms.Button();
            this.txtFileRootCertificate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAnswer_root_and_intermediate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_SelectKey
            // 
            this.btn_SelectKey.Location = new System.Drawing.Point(562, 13);
            this.btn_SelectKey.Name = "btn_SelectKey";
            this.btn_SelectKey.Size = new System.Drawing.Size(137, 36);
            this.btn_SelectKey.TabIndex = 0;
            this.btn_SelectKey.Text = "Select key\r\n秘密鍵を選択";
            this.btn_SelectKey.UseVisualStyleBackColor = true;
            this.btn_SelectKey.Click += new System.EventHandler(this.btn_SelectKey_Click);
            // 
            // btn_SelectServerCertificate
            // 
            this.btn_SelectServerCertificate.Location = new System.Drawing.Point(562, 13);
            this.btn_SelectServerCertificate.Name = "btn_SelectServerCertificate";
            this.btn_SelectServerCertificate.Size = new System.Drawing.Size(137, 51);
            this.btn_SelectServerCertificate.TabIndex = 1;
            this.btn_SelectServerCertificate.Text = "Select Server Certificate\r\nサーバ証明書を選択";
            this.btn_SelectServerCertificate.UseVisualStyleBackColor = true;
            this.btn_SelectServerCertificate.Click += new System.EventHandler(this.btn_SelectServerCertificate_Click);
            // 
            // btn_SelectIntermediateCertificate
            // 
            this.btn_SelectIntermediateCertificate.Location = new System.Drawing.Point(562, 15);
            this.btn_SelectIntermediateCertificate.Name = "btn_SelectIntermediateCertificate";
            this.btn_SelectIntermediateCertificate.Size = new System.Drawing.Size(137, 51);
            this.btn_SelectIntermediateCertificate.TabIndex = 2;
            this.btn_SelectIntermediateCertificate.Text = "Select Intermediate Certificate\r\n中間証明書を選択";
            this.btn_SelectIntermediateCertificate.UseVisualStyleBackColor = true;
            this.btn_SelectIntermediateCertificate.Click += new System.EventHandler(this.btn_SelectIntermediateCertificate_Click);
            // 
            // txtFileSecretKey
            // 
            this.txtFileSecretKey.Location = new System.Drawing.Point(6, 14);
            this.txtFileSecretKey.Name = "txtFileSecretKey";
            this.txtFileSecretKey.Size = new System.Drawing.Size(550, 19);
            this.txtFileSecretKey.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.txtFileSecretKey);
            this.groupBox1.Controls.Add(this.btn_SelectKey);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 55);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Server secret key - サーバ秘密鍵";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.lblInfo_serverCertificate);
            this.groupBox2.Controls.Add(this.txtFileServerCertificate);
            this.groupBox2.Controls.Add(this.btn_SelectServerCertificate);
            this.groupBox2.Location = new System.Drawing.Point(12, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 90);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Server Certificate - サーバ証明書";
            // 
            // lblInfo_serverCertificate
            // 
            this.lblInfo_serverCertificate.AutoSize = true;
            this.lblInfo_serverCertificate.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo_serverCertificate.Location = new System.Drawing.Point(16, 36);
            this.lblInfo_serverCertificate.Name = "lblInfo_serverCertificate";
            this.lblInfo_serverCertificate.Size = new System.Drawing.Size(9, 12);
            this.lblInfo_serverCertificate.TabIndex = 2;
            this.lblInfo_serverCertificate.Text = "_";
            // 
            // txtFileServerCertificate
            // 
            this.txtFileServerCertificate.Location = new System.Drawing.Point(12, 14);
            this.txtFileServerCertificate.Name = "txtFileServerCertificate";
            this.txtFileServerCertificate.Size = new System.Drawing.Size(544, 19);
            this.txtFileServerCertificate.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.lblInfo_intermediateCertificate);
            this.groupBox3.Controls.Add(this.txtFileIntermediateCertificate);
            this.groupBox3.Controls.Add(this.btn_SelectIntermediateCertificate);
            this.groupBox3.Location = new System.Drawing.Point(12, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(705, 90);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Intermediate Certificate - 中間証明書";
            // 
            // lblInfo_intermediateCertificate
            // 
            this.lblInfo_intermediateCertificate.AutoSize = true;
            this.lblInfo_intermediateCertificate.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo_intermediateCertificate.Location = new System.Drawing.Point(15, 39);
            this.lblInfo_intermediateCertificate.Name = "lblInfo_intermediateCertificate";
            this.lblInfo_intermediateCertificate.Size = new System.Drawing.Size(9, 12);
            this.lblInfo_intermediateCertificate.TabIndex = 3;
            this.lblInfo_intermediateCertificate.Text = "_";
            // 
            // txtFileIntermediateCertificate
            // 
            this.txtFileIntermediateCertificate.Location = new System.Drawing.Point(12, 17);
            this.txtFileIntermediateCertificate.Name = "txtFileIntermediateCertificate";
            this.txtFileIntermediateCertificate.Size = new System.Drawing.Size(544, 19);
            this.txtFileIntermediateCertificate.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(720, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 72);
            this.label4.TabIndex = 7;
            this.label4.Text = "←--\r\n      |\r\n      |\r\n      |\r\n      |\r\n←--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(720, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 72);
            this.label5.TabIndex = 8;
            this.label5.Text = "←--\r\n      |\r\n      |\r\n      |\r\n      |\r\n←--";
            // 
            // btnCompare
            // 
            this.btnCompare.BackColor = System.Drawing.SystemColors.Control;
            this.btnCompare.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCompare.Location = new System.Drawing.Point(723, 287);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(176, 63);
            this.btnCompare.TabIndex = 9;
            this.btnCompare.Text = "5.Compare\r\n比較開始";
            this.btnCompare.UseVisualStyleBackColor = false;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // lblAnswer_key_and_server
            // 
            this.lblAnswer_key_and_server.AutoSize = true;
            this.lblAnswer_key_and_server.BackColor = System.Drawing.Color.Silver;
            this.lblAnswer_key_and_server.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAnswer_key_and_server.Location = new System.Drawing.Point(751, 61);
            this.lblAnswer_key_and_server.Name = "lblAnswer_key_and_server";
            this.lblAnswer_key_and_server.Size = new System.Drawing.Size(139, 16);
            this.lblAnswer_key_and_server.TabIndex = 10;
            this.lblAnswer_key_and_server.Text = "Not compared yet...";
            // 
            // lblAnswer_server_and_intermediate
            // 
            this.lblAnswer_server_and_intermediate.AutoSize = true;
            this.lblAnswer_server_and_intermediate.BackColor = System.Drawing.Color.Silver;
            this.lblAnswer_server_and_intermediate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAnswer_server_and_intermediate.Location = new System.Drawing.Point(751, 151);
            this.lblAnswer_server_and_intermediate.Name = "lblAnswer_server_and_intermediate";
            this.lblAnswer_server_and_intermediate.Size = new System.Drawing.Size(139, 16);
            this.lblAnswer_server_and_intermediate.TabIndex = 11;
            this.lblAnswer_server_and_intermediate.Text = "Not compared yet...";
            // 
            // tmrStartCompare
            // 
            this.tmrStartCompare.Tick += new System.EventHandler(this.tmrStartCompare_Tick);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(5, 358);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(896, 164);
            this.txtStatus.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox4.Controls.Add(this.lblInfo_rootCertificate);
            this.groupBox4.Controls.Add(this.btn_SelectRootCertificate);
            this.groupBox4.Controls.Add(this.txtFileRootCertificate);
            this.groupBox4.Location = new System.Drawing.Point(12, 255);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(705, 90);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4. Root Certificate - ルート証明書";
            // 
            // lblInfo_rootCertificate
            // 
            this.lblInfo_rootCertificate.AutoSize = true;
            this.lblInfo_rootCertificate.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo_rootCertificate.Location = new System.Drawing.Point(15, 38);
            this.lblInfo_rootCertificate.Name = "lblInfo_rootCertificate";
            this.lblInfo_rootCertificate.Size = new System.Drawing.Size(9, 12);
            this.lblInfo_rootCertificate.TabIndex = 2;
            this.lblInfo_rootCertificate.Text = "_";
            // 
            // btn_SelectRootCertificate
            // 
            this.btn_SelectRootCertificate.Location = new System.Drawing.Point(562, 15);
            this.btn_SelectRootCertificate.Name = "btn_SelectRootCertificate";
            this.btn_SelectRootCertificate.Size = new System.Drawing.Size(137, 49);
            this.btn_SelectRootCertificate.TabIndex = 1;
            this.btn_SelectRootCertificate.Text = "Select Root Certificate\r\nルート証明書を選択";
            this.btn_SelectRootCertificate.UseVisualStyleBackColor = true;
            this.btn_SelectRootCertificate.Click += new System.EventHandler(this.btn_SelectRootCertificate_Click);
            // 
            // txtFileRootCertificate
            // 
            this.txtFileRootCertificate.Location = new System.Drawing.Point(12, 16);
            this.txtFileRootCertificate.Name = "txtFileRootCertificate";
            this.txtFileRootCertificate.Size = new System.Drawing.Size(544, 19);
            this.txtFileRootCertificate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(720, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 72);
            this.label1.TabIndex = 14;
            this.label1.Text = "←--\r\n      |\r\n      |\r\n      |\r\n      |\r\n←--";
            // 
            // lblAnswer_root_and_intermediate
            // 
            this.lblAnswer_root_and_intermediate.AutoSize = true;
            this.lblAnswer_root_and_intermediate.BackColor = System.Drawing.Color.Silver;
            this.lblAnswer_root_and_intermediate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAnswer_root_and_intermediate.Location = new System.Drawing.Point(751, 237);
            this.lblAnswer_root_and_intermediate.Name = "lblAnswer_root_and_intermediate";
            this.lblAnswer_root_and_intermediate.Size = new System.Drawing.Size(139, 16);
            this.lblAnswer_root_and_intermediate.TabIndex = 15;
            this.lblAnswer_root_and_intermediate.Text = "Not compared yet...";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 538);
            this.Controls.Add(this.lblAnswer_root_and_intermediate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblAnswer_server_and_intermediate);
            this.Controls.Add(this.lblAnswer_key_and_server);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "Certificates Comparer - 証明書比較くん2021";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SelectKey;
        private System.Windows.Forms.Button btn_SelectServerCertificate;
        private System.Windows.Forms.Button btn_SelectIntermediateCertificate;
        private System.Windows.Forms.TextBox txtFileSecretKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFileServerCertificate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFileIntermediateCertificate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label lblAnswer_key_and_server;
        private System.Windows.Forms.Label lblAnswer_server_and_intermediate;
        private System.Windows.Forms.Timer tmrStartCompare;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_SelectRootCertificate;
        private System.Windows.Forms.TextBox txtFileRootCertificate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAnswer_root_and_intermediate;
        private System.Windows.Forms.Label lblInfo_serverCertificate;
        private System.Windows.Forms.Label lblInfo_intermediateCertificate;
        private System.Windows.Forms.Label lblInfo_rootCertificate;
    }
}

