
namespace QC_Deploy
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            btnBackup = new System.Windows.Forms.Button();
            sshTextBox = new System.Windows.Forms.TextBox();
            btnConnect = new System.Windows.Forms.Button();
            webappsListBox = new System.Windows.Forms.CheckedListBox();
            radWebSrv = new System.Windows.Forms.RadioButton();
            radAppSrv = new System.Windows.Forms.RadioButton();
            servicesListBox = new System.Windows.Forms.CheckedListBox();
            cmbServers = new System.Windows.Forms.ComboBox();
            lblWebSrv = new System.Windows.Forms.Label();
            lblAppSrv = new System.Windows.Forms.Label();
            btnClean = new System.Windows.Forms.Button();
            btnDeploy = new System.Windows.Forms.Button();
            toolTipCtrl = new System.Windows.Forms.ToolTip(components);
            btnTouch = new System.Windows.Forms.Button();
            qStatus = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btnBackup
            // 
            btnBackup.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnBackup.Location = new System.Drawing.Point(958, 194);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new System.Drawing.Size(112, 70);
            btnBackup.TabIndex = 0;
            btnBackup.Text = "Ì";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // sshTextBox
            // 
            sshTextBox.BackColor = System.Drawing.Color.Navy;
            sshTextBox.ForeColor = System.Drawing.Color.White;
            sshTextBox.Location = new System.Drawing.Point(12, 526);
            sshTextBox.Multiline = true;
            sshTextBox.Name = "sshTextBox";
            sshTextBox.ReadOnly = true;
            sshTextBox.Size = new System.Drawing.Size(1058, 176);
            sshTextBox.TabIndex = 1;
            sshTextBox.Text = "test";
            // 
            // btnConnect
            // 
            btnConnect.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnConnect.Location = new System.Drawing.Point(958, 118);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(112, 70);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Ð";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // webappsListBox
            // 
            webappsListBox.CheckOnClick = true;
            webappsListBox.FormattingEnabled = true;
            webappsListBox.Location = new System.Drawing.Point(12, 68);
            webappsListBox.Name = "webappsListBox";
            webappsListBox.Size = new System.Drawing.Size(441, 424);
            webappsListBox.TabIndex = 4;
            webappsListBox.SelectedIndexChanged += webappsListBox_SelectedIndexChanged;
            // 
            // radWebSrv
            // 
            radWebSrv.AutoSize = true;
            radWebSrv.Location = new System.Drawing.Point(12, 32);
            radWebSrv.Name = "radWebSrv";
            radWebSrv.Size = new System.Drawing.Size(103, 29);
            radWebSrv.TabIndex = 6;
            radWebSrv.TabStop = true;
            radWebSrv.Text = "Web Srv";
            radWebSrv.UseVisualStyleBackColor = true;
            radWebSrv.CheckedChanged += radWebSrv_CheckedChanged;
            // 
            // radAppSrv
            // 
            radAppSrv.AutoSize = true;
            radAppSrv.Location = new System.Drawing.Point(466, 32);
            radAppSrv.Name = "radAppSrv";
            radAppSrv.Size = new System.Drawing.Size(101, 29);
            radAppSrv.TabIndex = 7;
            radAppSrv.TabStop = true;
            radAppSrv.Text = "App Srv";
            radAppSrv.UseVisualStyleBackColor = true;
            radAppSrv.CheckedChanged += radAppSrv_CheckedChanged;
            // 
            // servicesListBox
            // 
            servicesListBox.CheckOnClick = true;
            servicesListBox.FormattingEnabled = true;
            servicesListBox.Location = new System.Drawing.Point(466, 68);
            servicesListBox.Name = "servicesListBox";
            servicesListBox.Size = new System.Drawing.Size(441, 424);
            servicesListBox.TabIndex = 8;
            servicesListBox.SelectedIndexChanged += servicesListBox_SelectedIndexChanged;
            // 
            // cmbServers
            // 
            cmbServers.FormattingEnabled = true;
            cmbServers.Location = new System.Drawing.Point(924, 32);
            cmbServers.Name = "cmbServers";
            cmbServers.Size = new System.Drawing.Size(146, 33);
            cmbServers.TabIndex = 9;
            cmbServers.SelectedIndexChanged += cmbServers_SelectedIndexChanged;
            // 
            // lblWebSrv
            // 
            lblWebSrv.AutoSize = true;
            lblWebSrv.Location = new System.Drawing.Point(12, 498);
            lblWebSrv.Name = "lblWebSrv";
            lblWebSrv.Size = new System.Drawing.Size(41, 25);
            lblWebSrv.TabIndex = 15;
            lblWebSrv.Text = "test";
            // 
            // lblAppSrv
            // 
            lblAppSrv.AutoSize = true;
            lblAppSrv.Location = new System.Drawing.Point(466, 498);
            lblAppSrv.Name = "lblAppSrv";
            lblAppSrv.Size = new System.Drawing.Size(41, 25);
            lblAppSrv.TabIndex = 16;
            lblAppSrv.Text = "test";
            // 
            // btnClean
            // 
            btnClean.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClean.Location = new System.Drawing.Point(958, 422);
            btnClean.Name = "btnClean";
            btnClean.Size = new System.Drawing.Size(112, 70);
            btnClean.TabIndex = 17;
            btnClean.Text = "q";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // btnDeploy
            // 
            btnDeploy.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnDeploy.Location = new System.Drawing.Point(958, 346);
            btnDeploy.Name = "btnDeploy";
            btnDeploy.Size = new System.Drawing.Size(112, 70);
            btnDeploy.TabIndex = 18;
            btnDeploy.Text = "@";
            btnDeploy.UseVisualStyleBackColor = true;
            btnDeploy.Click += btnDeploy_Click;
            // 
            // btnTouch
            // 
            btnTouch.Font = new System.Drawing.Font("Wingdings", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnTouch.Location = new System.Drawing.Point(958, 270);
            btnTouch.Name = "btnTouch";
            btnTouch.Size = new System.Drawing.Size(112, 70);
            btnTouch.TabIndex = 19;
            btnTouch.Text = "I";
            btnTouch.UseVisualStyleBackColor = true;
            btnTouch.Click += btnTouch_Click;
            // 
            // qStatus
            // 
            qStatus.AutoSize = true;
            qStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            qStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            qStatus.Location = new System.Drawing.Point(924, 79);
            qStatus.Name = "qStatus";
            qStatus.Size = new System.Drawing.Size(67, 21);
            qStatus.TabIndex = 20;
            qStatus.Text = "qStatus";
            qStatus.TextChanged += qStatus_TextChanged;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1082, 714);
            Controls.Add(qStatus);
            Controls.Add(btnTouch);
            Controls.Add(btnDeploy);
            Controls.Add(btnClean);
            Controls.Add(lblAppSrv);
            Controls.Add(lblWebSrv);
            Controls.Add(cmbServers);
            Controls.Add(servicesListBox);
            Controls.Add(radAppSrv);
            Controls.Add(radWebSrv);
            Controls.Add(webappsListBox);
            Controls.Add(btnConnect);
            Controls.Add(sshTextBox);
            Controls.Add(btnBackup);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "mainForm";
            Text = "QC Deploy v1.0";
            FormClosing += mainForm_FormClosing;
            Load += mainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.TextBox sshTextBox;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckedListBox webappsListBox;
        private System.Windows.Forms.RadioButton radWebSrv;
        private System.Windows.Forms.RadioButton radAppSrv;
        private System.Windows.Forms.CheckedListBox servicesListBox;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.Label lblWebSrv;
        private System.Windows.Forms.Label lblAppSrv;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.ToolTip toolTipCtrl;
        private System.Windows.Forms.Button btnTouch;
        private System.Windows.Forms.Label qStatus;
    }
}

