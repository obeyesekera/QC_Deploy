using System;
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
            if (btnConnect.Text == "Ð") // Connect to server
            {
                setqStatus("CONNECTING");
                connectServer();
            }
            else // Disconnect from server
            {
                setqStatus("DISCONNECTING");
                DialogResult dialogResult = MessageBox.Show(disconnectDialogMessage, disconnectDialogTitle, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    disconnectServer();
                }
                else if (dialogResult == DialogResult.No)
                {
                    setqStatus();
                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            setqStatus("BACKUP START");

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
                setqStatus("BACKUP DONE");
                isBackup = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                setqStatus();
            }
        }

        private void btnTouch_Click(object sender, EventArgs e)
        {
            setqStatus("TOUCHING");

            DialogResult dialogResult = MessageBox.Show(touchDialogMessage, touchDialogTitle, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (radWebSrv.Checked)
                {
                    touchWebApps();
                }
                else
                {
                    touchServices();
                }
                setqStatus("TOUCHED");
                delBackup = true;
                isBackup=false;
                setBtnCleanFiles();
            }
            else if (dialogResult == DialogResult.No)
            {
                setqStatus();
            }
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            setqStatus("DEPLOYING");

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
                setqStatus("DEPLOYED");
                delBackup = true;
                isBackup = false;
                setBtnCleanFiles();
            }
            else if (dialogResult == DialogResult.No)
            {
                setqStatus();
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            setqStatus("CLEANING");

            string msg;

            if (delBackup)
            {
                msg = cleanFileDialogMessage;
            }
            else
            {
                msg = cleanLogDialogMessage;
            }

            DialogResult dialogResult = MessageBox.Show(msg, cleanDialogTitle, MessageBoxButtons.YesNo);
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
                setqStatus();
            }
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
            if (isConnected)
            {
                string msg;

                if (btnConnect.Enabled)
                {
                    msg = closeDialogConfirmMessage;
                }
                else
                {
                    if (btnDeploy.Enabled) {
                        msg = closeDialogErrorMessage; 
                    }
                    else
                    {
                        msg = closeDialogWarningMessage; 
                    }
                }

                DialogResult dialogResult = MessageBox.Show(msg, closeDialogTitle, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    disconnectServer();
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void qStatus_TextChanged(object sender, EventArgs e)
        {
            setBtnStatus();
        }
    }
}
