using System;
using System.Drawing;
using System.Windows.Forms;

namespace QC_Deploy
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        
        private void mainForm_Load(object sender, EventArgs e)
        {
            pageLoad();
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Ð")
            {
                btnConnect.Text = "Ï";
                btnConnect.ForeColor = Color.Green;
                toolTipCtrl.SetToolTip(btnConnect, "Disconnect");
                cmbServers.Enabled = false;
                radWebSrv.Enabled = false;
                radAppSrv.Enabled = false;
                webappsListBox.Enabled = false;
                servicesListBox.Enabled = false;
                connectServer();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(disconnectDialogMessage, disconnectDialogTitle, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    btnBackup.Enabled = false;
                    btnClean.Enabled = false;
                    btnDeploy.Enabled = false;
                    disconnectServer();
                    btnConnect.Text = "Ð";
                    btnConnect.ForeColor = Color.Red;
                    toolTipCtrl.SetToolTip(btnConnect, "Connect");
                    cmbServers.Enabled = true;
                    radWebSrv.Enabled = true;
                    radAppSrv.Enabled = true;
                    webappsListBox.Enabled = true;
                    servicesListBox.Enabled = true;
                }
            }
        }


        private void btnBackup_Click(object sender, EventArgs e)
        {
            btnBackup.Enabled = false;
            btnConnect.Enabled = false;

            DialogResult dialogResult = MessageBox.Show(backupDialogMessage, backupDialogTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (radWebSrv.Checked)
                {
                    backupWebApps();
                }
                else
                {
                    backupServices();
                }

                btnDeploy.Enabled = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                btnBackup.Enabled = true;
            }

            btnConnect.Enabled = true;
        }


        private void btnDeploy_Click(object sender, EventArgs e)
        {
            btnDeploy.Enabled = false;
            btnConnect.Enabled = false;

            DialogResult dialogResult = MessageBox.Show(deployDialogMessage, deployDialogTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (radWebSrv.Checked)
                {
                    deployWebApps();
                }
                else
                {
                    deployServices();
                }

                btnClean.Enabled = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                btnDeploy.Enabled = true;
            }

            btnConnect.Enabled = true;
        }


        private void btnClean_Click(object sender, EventArgs e)
        {
            btnClean.Enabled = false;
            btnConnect.Enabled = false;

            DialogResult dialogResult = MessageBox.Show(cleanpDialogMessage, cleanDialogTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (radWebSrv.Checked)
                {
                    cleanWebApps();
                }
                else
                {
                    cleanServices();
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                btnClean.Enabled = true;
            }

            btnConnect.Enabled = true;
        }




        private void radWebSrv_CheckedChanged(object sender, EventArgs e)
        {
            if (isTrigger && radWebSrv.Checked)
            {
                btnConnect.Enabled = webServer.getRequired();
            }

            sshTextBoxClear();
        }

        private void radAppSrv_CheckedChanged(object sender, EventArgs e)
        {
            if (isTrigger && radAppSrv.Checked)
            {
                btnConnect.Enabled = appServer.getRequired();
            }

            sshTextBoxClear();
        }

        private void cmbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isTrigger)
            {
                appServer.setServer(serverCon, cmbServers.SelectedIndex, "A");
                webServer.setServer(serverCon, cmbServers.SelectedIndex, "W");

                updateServerNames();
                sshTextBoxClear();

            }
        }

        private void webappsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isTrigger)
            {
                if (webappsListBox.CheckedItems.Count > 0)
                {
                    webServer.setWebRequired(true);
                }
                else
                {
                    webServer.setWebRequired(false);
                }


                if (radWebSrv.Checked)
                {
                    btnConnect.Enabled = webServer.getRequired();
                }

            }
        }

        private void servicesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isTrigger)
            {
                if (servicesListBox.CheckedItems.Count > 0)
                {
                    appServer.setServiceRequired(true);
                }
                else
                {
                    appServer.setServiceRequired(false);
                }


                if (radAppSrv.Checked)
                {
                    btnConnect.Enabled = appServer.getRequired();
                }

            }
        }

         

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
