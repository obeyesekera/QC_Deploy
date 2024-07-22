
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.btnBackup = new System.Windows.Forms.Button();
            this.sshTextBox = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.webappsListBox = new System.Windows.Forms.CheckedListBox();
            this.radWebSrv = new System.Windows.Forms.RadioButton();
            this.radAppSrv = new System.Windows.Forms.RadioButton();
            this.servicesListBox = new System.Windows.Forms.CheckedListBox();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.lblWebSrv = new System.Windows.Forms.Label();
            this.lblAppSrv = new System.Windows.Forms.Label();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.toolTipCtrl = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBackup.Location = new System.Drawing.Point(958, 194);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(112, 84);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "Ì";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // sshTextBox
            // 
            this.sshTextBox.BackColor = System.Drawing.Color.Navy;
            this.sshTextBox.ForeColor = System.Drawing.Color.White;
            this.sshTextBox.Location = new System.Drawing.Point(12, 526);
            this.sshTextBox.Multiline = true;
            this.sshTextBox.Name = "sshTextBox";
            this.sshTextBox.ReadOnly = true;
            this.sshTextBox.Size = new System.Drawing.Size(1058, 176);
            this.sshTextBox.TabIndex = 1;
            this.sshTextBox.Text = "test";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConnect.Location = new System.Drawing.Point(958, 104);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 84);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Ð";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // webappsListBox
            // 
            this.webappsListBox.CheckOnClick = true;
            this.webappsListBox.FormattingEnabled = true;
            this.webappsListBox.Location = new System.Drawing.Point(12, 68);
            this.webappsListBox.Name = "webappsListBox";
            this.webappsListBox.Size = new System.Drawing.Size(441, 424);
            this.webappsListBox.TabIndex = 4;
            this.webappsListBox.SelectedIndexChanged += new System.EventHandler(this.webappsListBox_SelectedIndexChanged);
            // 
            // radWebSrv
            // 
            this.radWebSrv.AutoSize = true;
            this.radWebSrv.Location = new System.Drawing.Point(12, 32);
            this.radWebSrv.Name = "radWebSrv";
            this.radWebSrv.Size = new System.Drawing.Size(103, 29);
            this.radWebSrv.TabIndex = 6;
            this.radWebSrv.TabStop = true;
            this.radWebSrv.Text = "Web Srv";
            this.radWebSrv.UseVisualStyleBackColor = true;
            this.radWebSrv.CheckedChanged += new System.EventHandler(this.radWebSrv_CheckedChanged);
            // 
            // radAppSrv
            // 
            this.radAppSrv.AutoSize = true;
            this.radAppSrv.Location = new System.Drawing.Point(466, 32);
            this.radAppSrv.Name = "radAppSrv";
            this.radAppSrv.Size = new System.Drawing.Size(101, 29);
            this.radAppSrv.TabIndex = 7;
            this.radAppSrv.TabStop = true;
            this.radAppSrv.Text = "App Srv";
            this.radAppSrv.UseVisualStyleBackColor = true;
            this.radAppSrv.CheckedChanged += new System.EventHandler(this.radAppSrv_CheckedChanged);
            // 
            // servicesListBox
            // 
            this.servicesListBox.CheckOnClick = true;
            this.servicesListBox.FormattingEnabled = true;
            this.servicesListBox.Location = new System.Drawing.Point(466, 68);
            this.servicesListBox.Name = "servicesListBox";
            this.servicesListBox.Size = new System.Drawing.Size(441, 424);
            this.servicesListBox.TabIndex = 8;
            this.servicesListBox.SelectedIndexChanged += new System.EventHandler(this.servicesListBox_SelectedIndexChanged);
            // 
            // cmbServers
            // 
            this.cmbServers.FormattingEnabled = true;
            this.cmbServers.Location = new System.Drawing.Point(924, 32);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Size = new System.Drawing.Size(146, 33);
            this.cmbServers.TabIndex = 9;
            this.cmbServers.SelectedIndexChanged += new System.EventHandler(this.cmbServers_SelectedIndexChanged);
            // 
            // lblWebSrv
            // 
            this.lblWebSrv.AutoSize = true;
            this.lblWebSrv.Location = new System.Drawing.Point(12, 498);
            this.lblWebSrv.Name = "lblWebSrv";
            this.lblWebSrv.Size = new System.Drawing.Size(41, 25);
            this.lblWebSrv.TabIndex = 15;
            this.lblWebSrv.Text = "test";
            // 
            // lblAppSrv
            // 
            this.lblAppSrv.AutoSize = true;
            this.lblAppSrv.Location = new System.Drawing.Point(466, 498);
            this.lblAppSrv.Name = "lblAppSrv";
            this.lblAppSrv.Size = new System.Drawing.Size(41, 25);
            this.lblAppSrv.TabIndex = 16;
            this.lblAppSrv.Text = "test";
            // 
            // btnClean
            // 
            this.btnClean.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClean.Location = new System.Drawing.Point(958, 374);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(112, 84);
            this.btnClean.TabIndex = 17;
            this.btnClean.Text = "q";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnDeploy
            // 
            this.btnDeploy.Font = new System.Drawing.Font("Webdings", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeploy.Location = new System.Drawing.Point(958, 284);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(112, 84);
            this.btnDeploy.TabIndex = 18;
            this.btnDeploy.Text = "@";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 714);
            this.Controls.Add(this.btnDeploy);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.lblAppSrv);
            this.Controls.Add(this.lblWebSrv);
            this.Controls.Add(this.cmbServers);
            this.Controls.Add(this.servicesListBox);
            this.Controls.Add(this.radAppSrv);
            this.Controls.Add(this.radWebSrv);
            this.Controls.Add(this.webappsListBox);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.sshTextBox);
            this.Controls.Add(this.btnBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.Text = "QC Deploy v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

