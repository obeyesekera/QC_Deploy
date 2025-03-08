using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QC_Deploy
{
    partial class mainForm
    {
        private Boolean isTrigger;
        private Boolean isConnected;
        private string[,] serverCon;
        private Boolean delBackup;
        private Boolean isBackup;

        Server appServer;
        Server webServer;

        private string prevStatus;

        private void pageLoad()
        {
            //set version info
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "QC Deploy v" + version;

            setqStatus("DISCONNECTED");
            btnConnect.Enabled = false;

            cmbServers.DropDownStyle = ComboBoxStyle.DropDownList;

            isTrigger = false;
            isConnected = false;
            delBackup = false;
            isBackup = false;

            radWebSrv.Checked = true;

            sshTextBoxClear();

            sshTextBox.ReadOnly = true;
            sshTextBox.Font = new Font("Courier", 8);

            webappsListBox.DataSource = File.ReadAllLines(webappsList);
            servicesListBox.DataSource = File.ReadAllLines(servicesList);
            fillServerComboBox(serverList);

            appServer = new Server(serverCon, cmbServers.SelectedIndex, "A");
            webServer = new Server(serverCon, cmbServers.SelectedIndex, "W");

            updateServerNames();

            webWebapps = webServer.getWebappsPath();
            serviceWebapps = appServer.getWebappsPath();

            isTrigger = true;

            btnConnect.Focus();
            btnConnect.ForeColor = Color.Red;

            setBtnCleanLogs();
            setBtnConnect();
        }

        private void setqStatus(string newStatus)
        {
            prevStatus = qStatus.Text;
            qStatus.Text = newStatus;
        }

        private void setqStatus()
        {
            qStatus.Text = prevStatus;
        }

        private string getqStatus()
        {
            return qStatus.Text;
        }

        private void updateServerNames()
        {
            lblAppSrv.Text = serverCon[cmbServers.SelectedIndex, 2].Trim() + "@" + serverCon[cmbServers.SelectedIndex, 1].Trim();
            lblWebSrv.Text = serverCon[cmbServers.SelectedIndex, 5].Trim() + "@" + serverCon[cmbServers.SelectedIndex, 4].Trim();
        }

        private string[,] readComboCfg(string cfgName)
        {
            //Env Name, App IP, App UN, App PW, Web IP, Web UN, Web PW, Rel Path, App Path, Web Path, App Logs Path, Web Logs Path

            int parmCount = 12;
            string[] lineOfContents = File.ReadAllLines(cfgName);
            string[,] cfgConnections = new string[lineOfContents.Length, parmCount];
            int i = 0;
            foreach (var line in lineOfContents)
            {
                string[] parVals = line.Split(',');
                

                for(int j = 0; j < parmCount; j++)
                {
                    cfgConnections[i, j] = parVals[j].Trim();
                }

                i++;
            }

            return cfgConnections;
        }

        private void fillServerComboBox(string cfgFile)
        {
            serverCon = readComboCfg(cfgFile);

            for (int i = 0; i < serverCon.GetLength(0); i++)
            {
                cmbServers.Items.Add(serverCon[i, 0]);
            }

            cmbServers.SelectedIndex = 0;
        }

        private void setTooltip(string btnConnectTT, string btnCleanTT)
        {
            string btnConnectPrevTT = toolTipCtrl.GetToolTip(btnConnect);
            string btnCleanPrevTT = toolTipCtrl.GetToolTip(btnClean);

            if (btnConnectTT.Length > 0)
            {
                toolTipCtrl.SetToolTip(btnConnect, btnConnectTT);
            }
            else
            {
                toolTipCtrl.SetToolTip(btnConnect, btnConnectPrevTT);
            }
            toolTipCtrl.SetToolTip(btnBackup, "Backup");
            toolTipCtrl.SetToolTip(btnDeploy, "Build");
            toolTipCtrl.SetToolTip(btnTouch, "Touch");
            if (btnCleanTT.Length > 0)
            {
                toolTipCtrl.SetToolTip(btnClean, btnCleanTT);
            }
            else
            {
                toolTipCtrl.SetToolTip(btnClean, btnCleanPrevTT);
            }
        }


        private void setBtnConnect()
        {
            btnConnect.Text = "Ð";
            btnConnect.ForeColor = Color.Red;
            setTooltip("Connect", "");
        }

        private void setBtnDisconnect()
        {
            btnConnect.Text = "Ï";
            btnConnect.ForeColor = Color.Green;
            setTooltip("Disconnect", "");
        }

        private void setBtnCleanFiles()
        {
            btnClean.ForeColor = Color.Red;
            setTooltip("", "Clean Backups");
        }

        private void setBtnCleanLogs()
        {
            btnClean.ForeColor = Color.Blue;
            setTooltip("", "Clen Logs");
        }

        private void connectServer()
        {
            sshTextBoxClear();

            if (radWebSrv.Checked)
            {
                if (webServer.getRequired())
                {
                    string connectionResult;

                    if (runSSH)
                    {
                        connectionResult = webServer.connectServer();

                        if (connectionResult == "Connected to : " + webServer.getIP())
                        {
                            isConnected = true;
                            setBtnDisconnect();
                            setqStatus("CONNECTED");
                        }
                        else
                        {
                            setBtnConnect();
                            setqStatus("DISCONNECTED");
                        }
                    }
                    else
                    {
                        connectionResult = "Connected to : DUMMY SERVER";

                        if (getqStatus() == "CONNECTING")
                        {
                            isConnected = true;
                            setBtnDisconnect();
                            setqStatus("CONNECTED");
                        }
                        else
                        {
                            setBtnConnect();
                            setqStatus("DISCONNECTED");
                        }
                    }
                    sshTextBoxPrint(connectionResult, "R");
                }
            }
            else
            {
                if (appServer.getRequired())
                {
                    string connectionResult;

                    if (runSSH)
                    {
                        connectionResult = appServer.connectServer();

                        if (connectionResult == "Connected to : " + appServer.getIP())
                        {
                            isConnected = true;
                            setBtnDisconnect();
                            setqStatus("CONNECTED");
                        }
                        else
                        {
                            setBtnConnect();
                            setqStatus("DISCONNECTED");
                        }
                    }
                    else
                    {
                        connectionResult = "Connected to : DUMMY SERVER";

                        if (getqStatus() == "CONNECTING")
                        {
                            isConnected = true;
                            setBtnDisconnect();
                            setqStatus("CONNECTED");
                        }
                        else
                        {
                            setBtnConnect();
                            setqStatus("DISCONNECTED");
                        }
                    }
                    sshTextBoxPrint(connectionResult, "R");
                }
            }
        }

        private void disconnectServer()
        {
            string connectionResult;

            if (runSSH)
            {
                if (radWebSrv.Checked)
                {
                    sshTextBoxPrint(webServer.disconnectServer(), "R");
                }
                else
                {
                    sshTextBoxPrint(appServer.disconnectServer(), "R");
                }
                setBtnConnect();
                setqStatus("DISCONNECTED");
            }
            else
            {
                connectionResult = "Disconnected from : DUMMY SERVER";
                sshTextBoxPrint(connectionResult, "R");
                setBtnConnect();
                setqStatus("DISCONNECTED");
            }
            isConnected = false;
        }

        private void backupWebApps()
        {
            foreach (var webModule in webappsListBox.CheckedItems)
            {
                string mvCommand = backupWebAppsMV(webModule.ToString());
                executeCommand(mvCommand, "W");
            }
        }

        private void backupServices()
        {
            foreach (var appService in servicesListBox.CheckedItems)
            {
                string mvCommand = backupServicesMV(appService.ToString());
                executeCommand(mvCommand, "A");

                string rmCommand = backupServicesRM(appService.ToString());
                executeCommand(rmCommand, "A");
            }
        }

        private void deployWebApps()
        {
            foreach (var webModule in webappsListBox.CheckedItems)
            {
                string scpCommand = deployWebAppsSCP(webModule.ToString());
                sshTextBoxPrint(scpCommand, "D");
            }
        }

        private void deployServices()
        {
            foreach (var appService in servicesListBox.CheckedItems)
            {
                string scpCommand = deployServicesSCP(appService.ToString());
                sshTextBoxPrint(scpCommand, "D");
            }
        }

        private void touchWebApps()
        {
            foreach (var webModule in webappsListBox.CheckedItems)
            {
                string touchRMCommand = touchWebAppsRM(webModule.ToString());
                executeCommand(touchRMCommand, "W");
                string touchMVCommand = touchWebAppsMV(webModule.ToString());
                executeCommand(touchMVCommand, "W");
            }
        }

        private void touchServices()
        {
            foreach (var appService in servicesListBox.CheckedItems)
            {
                string touchRMCommand = touchServicesRM(appService.ToString());
                executeCommand(touchRMCommand, "A");
                string touchMVCommand = touchServicesMV(appService.ToString());
                executeCommand(touchMVCommand, "A");
            }
        }

        private void cleanWebApps()
        {
            if (delBackup)
            {
                foreach (var webModule in webappsListBox.CheckedItems)
                {
                    string rmCommand = cleanWebAppsRM(webModule.ToString());
                    executeCommand(rmCommand, "W");
                }
                setqStatus("CLEANED");
                setBtnCleanLogs();
            }
            string catCommand = cleanWebAppsLogs();
            executeCommand(catCommand, "W");

            if (isBackup)
            {
                setqStatus("BACKUP DONE");
            }
            else
            {
                setqStatus("CLEANED");
                delBackup = false;
            }
        }

        private void cleanServices()
        {
            if (delBackup)
            {
                foreach (var appService in servicesListBox.CheckedItems)
                {
                    string rmCommand = cleanServicesRM(appService.ToString());
                    executeCommand(rmCommand, "A");
                }
                setqStatus("CLEANED");
                setBtnCleanLogs();
            }
            string catCommand = cleanServicesLogs();
            executeCommand(catCommand, "A");

            if (isBackup)
            {
                setqStatus("BACKUP DONE");
            }
            else {
                setqStatus("CLEANED");
                delBackup = false;
            }
        }

        private void executeCommand(string newCommand, string srvType)
        {
            if (runSSH)
            {
                sshTextBoxPrint(newCommand, "C");

                if (srvType == "A")
                {
                    sshTextBoxPrint(appServer.executeCommand(newCommand), "R");
                }
                else
                {
                    sshTextBoxPrint(webServer.executeCommand(newCommand), "R");
                }
            }
            else
            {
                sshTextBoxPrint(newCommand, "D");
            }
        }

        private void sshTextBoxPrint(string sshText, string txtType)
        {
            if (txtType == "C")
            {
                sshText = "> " + sshText;
            }
            else if (txtType == "D")
            {
                sshText = "DUMMY> " + sshText;
            }

            sshTextBox.AppendText(sshText + "\r\n");
        }

        private void sshTextBoxClear()
        {
            sshTextBox.Clear();
        }

        private void setBtnStatus()
        {
            switch(getqStatus())
            {
                case "DISCONNECTED":
                    btnConnect.Enabled = true;
                    btnBackup.Enabled = false;
                    btnDeploy.Enabled = false;
                    btnTouch.Enabled = false;
                    btnClean.Enabled = false;
                    setUIComp(true);
                    break;
                case "CONNECTED":
                    btnConnect.Enabled = true;
                    btnBackup.Enabled = true;
                    btnDeploy.Enabled = false;
                    btnTouch.Enabled = false;
                    btnClean.Enabled = true;
                    break;
                case "BACKUP DONE":
                    btnConnect.Enabled = false;
                    btnBackup.Enabled = false;
                    btnDeploy.Enabled = true;
                    btnTouch.Enabled = true;
                    btnClean.Enabled = true;
                    break;
                case "DEPLOYED":
                    btnConnect.Enabled = false;
                    btnBackup.Enabled = false;
                    btnDeploy.Enabled = false;
                    btnTouch.Enabled = false;
                    btnClean.Enabled = true;
                    break;
                case "TOUCHED":
                    btnConnect.Enabled = false;
                    btnBackup.Enabled = false;
                    btnDeploy.Enabled = false;
                    btnTouch.Enabled = false;
                    btnClean.Enabled = true;
                    break;
                case "CLEANED":
                    btnConnect.Enabled = true;
                    btnBackup.Enabled = true;
                    btnDeploy.Enabled = false;
                    btnTouch.Enabled = false;
                    btnClean.Enabled = true;
                    break;
                default:
                    btnConnect.Enabled = false;
                    btnBackup.Enabled = false;
                    btnDeploy.Enabled = false;
                    btnTouch.Enabled = false;
                    btnClean.Enabled = false;
                    setUIComp(false);
                    break;
            }
        }

        private void setUIComp(bool sts)
        {
            cmbServers.Enabled = sts;
            radWebSrv.Enabled = sts;
            radAppSrv.Enabled = sts;
            webappsListBox.Enabled = sts;
            servicesListBox.Enabled = sts;
        }


    }
}
