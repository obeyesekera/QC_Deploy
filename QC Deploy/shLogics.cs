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

        Server appServer;
        Server webServer;


        private void pageLoad()
        {
            btnConnect.Enabled = false;
            btnBackup.Enabled = false;
            btnDeploy.Enabled = false;
            btnClean.Enabled = false;

            cmbServers.DropDownStyle = ComboBoxStyle.DropDownList;

            isTrigger = false;
            isConnected = false;

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

            isTrigger = true;

            btnConnect.Focus();
            btnConnect.ForeColor = Color.Red;

            setTooltip("Connect");
        }

        private void updateServerNames()
        {
            lblAppSrv.Text = serverCon[cmbServers.SelectedIndex, 2].Trim() + "@" + serverCon[cmbServers.SelectedIndex, 1].Trim();
            lblWebSrv.Text = serverCon[cmbServers.SelectedIndex, 5].Trim() + "@" + serverCon[cmbServers.SelectedIndex, 4].Trim();
        }

        private string[,] readComboCfg(string cfgName)
        {
            string[] lineOfContents = File.ReadAllLines(cfgName);
            string[,] cfgConnections = new string[lineOfContents.Length, 7];
            int i = 0;
            foreach (var line in lineOfContents)
            {
                string[] parVals = line.Split(',');
                cfgConnections[i, 0] = parVals[0]; //Env Name
                cfgConnections[i, 1] = parVals[1]; //App IP
                cfgConnections[i, 2] = parVals[2]; //App UN
                cfgConnections[i, 3] = parVals[3]; //App PW
                cfgConnections[i, 4] = parVals[4]; //Web IP
                cfgConnections[i, 5] = parVals[5]; //Web UN
                cfgConnections[i, 6] = parVals[6]; //Web PW
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

        private void setTooltip(string btnConTT)
        {
            toolTipCtrl.SetToolTip(btnConnect, btnConTT);
            toolTipCtrl.SetToolTip(btnBackup, "Backup");
            toolTipCtrl.SetToolTip(btnDeploy, "Build");
            toolTipCtrl.SetToolTip(btnClean, "Clean");
        }


        private void setConnect()
        {
            btnConnect.Text = "Ð";
            btnConnect.ForeColor = Color.Red;
            setTooltip("Connect");
            cmbServers.Enabled = true;
            radWebSrv.Enabled = true;
            radAppSrv.Enabled = true;
            webappsListBox.Enabled = true;
            servicesListBox.Enabled = true;
        }

        private void setDisconnect()
        {
            btnConnect.Text = "Ï";
            btnConnect.ForeColor = Color.Green;
            setTooltip("Disconnect");
            cmbServers.Enabled = false;
            radWebSrv.Enabled = false;
            radAppSrv.Enabled = false;
            webappsListBox.Enabled = false;
            servicesListBox.Enabled = false;
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
                            btnBackup.Enabled = true;
                            isConnected = true;
                        }
                        else
                        {
                            setConnect();
                        }

                    }
                    else
                    {
                        connectionResult = "Connected to : DUMMY SERVER";
                        btnBackup.Enabled = true;
                    }

                    btnConnect.Enabled = true;
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
                            btnBackup.Enabled = true;
                            isConnected = true;
                        }
                        else
                        {
                            setConnect();
                        }

                    }
                    else
                    {
                        connectionResult = "Connected to : DUMMY SERVER";
                        btnBackup.Enabled = true;
                    }

                    btnConnect.Enabled = true;
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
                isConnected = false;
            }
            else
            {
                connectionResult = "Disconnected from : DUMMY SERVER";
                sshTextBoxPrint(connectionResult, "R");
            }

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


        private void cleanWebApps()
        {
            foreach (var webModule in webappsListBox.CheckedItems)
            {
                string rmCommand = cleanWebAppsRM(webModule.ToString());
                executeCommand(rmCommand, "W");
            }
            string catCommand = cleanLogs();
            executeCommand(catCommand, "W");
        }

        private void cleanServices()
        {
            foreach (var appService in servicesListBox.CheckedItems)
            {
                string rmCommand = cleanServicesRM(appService.ToString());
                executeCommand(rmCommand, "A");
            }

            string catCommand = cleanLogs();
            executeCommand(catCommand, "A");
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
    }
}
