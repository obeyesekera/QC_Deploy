﻿using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QC_Deploy
{
    class Server
    {
        string IP;
        string UN;
        string PW;
        string TYP;
        string releasePATH;
        string backupPATH;
        string webappsPATH;
        string logsPATH;

        Boolean isRequired = false;
        Boolean isWebappRequired = false;
        Boolean isServiceRequired = false;
        Boolean isLibRequired = false;
        Boolean isConfigRequired = false;

        SshClient sshclient;

        public Server(string[,] connections, int srvID, string srvType)
        {
            setServer(connections, srvID, srvType);
        }

        public void setServer(string[,] connections, int srvID, string srvType)
        {
            TYP = srvType;
            if (srvType == "A")
            {
                IP = connections[srvID, 1].Trim();
                UN = connections[srvID, 2].Trim();
                PW = connections[srvID, 3].Trim();
                webappsPATH = connections[srvID, 8].Trim();
                logsPATH = connections[srvID, 10].Trim();
                backupPATH = connections[srvID, 12].Trim();
            }
            else
            {
                IP = connections[srvID, 4].Trim();
                UN = connections[srvID, 5].Trim();
                PW = connections[srvID, 6].Trim();
                webappsPATH = connections[srvID, 9].Trim();
                logsPATH = connections[srvID, 11].Trim();
                backupPATH = connections[srvID, 13].Trim();
            }
            releasePATH = connections[srvID, 7].Trim();
        }

        public string connectServer()
        {
            try
            {
                sshclient = new SshClient(IP, UN, PW);
                sshclient.Connect();
                return "Connected to : " + sshclient.ConnectionInfo.Host;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string disconnectServer()
        {
            try
            {
                sshclient.Disconnect();
                sshclient.Dispose();
                return "Disconnected";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string executeCommand(string newCommand)
        {
            try
            {
                SshCommand sc = sshclient.CreateCommand(newCommand);
                sc.Execute();
                string Result = sc.Result;
                sc.Dispose();
                return Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string getHostUser()
        {
            return UN + "@" + IP;
        }

        public void setWebRequired(Boolean status)
        {
            isWebappRequired = status;
            setAppRequired();
        }

        public void setServiceRequired(Boolean status)
        {
            isServiceRequired = status;
            setAppRequired();
        }

        public void setLibRequired(Boolean status)
        {
            isLibRequired = status;
            setAppRequired();
        }

        public void setConfigRequired(Boolean status)
        {
            isConfigRequired = status;
            setAppRequired();
        }

        private void setAppRequired()
        {
            if (isWebappRequired || isServiceRequired || isLibRequired || isConfigRequired)
            {
                isRequired = true;
            }
            else
            {
                isRequired = false;
            }
        }

        public Boolean getRequired()
        {
            return isRequired;
        }

        public Boolean getServiceRequired()
        {
            return isServiceRequired;
        }

        public Boolean getLibRequired()
        {
            return isLibRequired;
        }

        public Boolean getConfigRequired()
        {
            return isConfigRequired;
        }

        public string getIP()
        {
            return IP;
        }

        public string getWebappsPath()
        {
            return webappsPATH;
        }

        public string getLogsPath()
        {
            return logsPATH;
        }

        public string getBackupPath()
        {
            return backupPATH;
        }
    }
}
