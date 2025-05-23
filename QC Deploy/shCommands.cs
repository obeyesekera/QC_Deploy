﻿namespace QC_Deploy
{
    partial class mainForm
    {
        string webWebapps;
        string serviceWebapps;
        string webLogs;
        string serviceLogs;
        string webBackup;
        string serviceBackup;

        private string backupWebAppsMV(string webModule)
        {
            //string mvCommand = "mv " + webWebapps + webModule + " " + webWebapps + "bk_" + webModule;
            string mvCommand = "mv " + webWebapps + webModule + " " + webBackup + webModule;
            return mvCommand;
        }

        private string backupServicesMV(string appService)
        {
            //string mvCommand = "mv " + serviceWebapps + appService + ".war " + serviceWebapps + "bk/" + appService + ".war";
            string mvCommand = "mv " + serviceWebapps + appService + ".war " + serviceBackup + appService + ".war";
            return mvCommand;
        }

        private string backupServicesRM(string appService)
        {
            string rmCommand = "rm -rf " + serviceWebapps + appService;
            return rmCommand;
        }

        private string deployWebAppsSCP(string webModule)
        {
            string scpCommand = webModule + " build COMPLETE";
            return scpCommand;
        }

        private string deployServicesSCP(string appService)
        {
            string scpCommand = appService + " build COMPLETE";
            return scpCommand;
        }
                
        private string touchWebAppsRM(string webModule)
        {
            string mvCommand = "rm -rf " + webWebapps + webModule;
            return mvCommand;
        }

        private string touchServicesRM(string appService)
        {
            string mvCommand = "rm -rf " + serviceWebapps + appService + ".war";
            return mvCommand;
        }

        private string touchWebAppsMV(string webModule)
        {
            //string mvCommand = "mv " + webWebapps + "bk_" + webModule + " " + webWebapps + webModule;
            string mvCommand = "mv " + webBackup + webModule + " " + webWebapps + webModule;
            return mvCommand;
        }

        private string touchServicesMV(string appService)
        {
            //string mvCommand = "mv " + serviceWebapps + "bk/" + appService + ".war " + serviceWebapps + appService + ".war";
            string mvCommand = "mv " + serviceBackup + appService + ".war " + serviceWebapps + appService + ".war";
            return mvCommand;
        }

        private string cleanWebAppsRM(string webModule)
        {
            string rmCommand = "rm -rf " + webBackup + webModule;
            return rmCommand;
        }

        private string cleanServicesRM(string appService)
        {
            string rmCommand = "rm " + serviceBackup + appService + ".war";
            return rmCommand;
        }

        private string cleanWebAppsLogs()
        {
            string catCommand = "cat /dev/null > " + webLogs + "catalina.out";
            return catCommand;
        }

        private string cleanServicesLogs()
        {
            string catCommand = "cat /dev/null > " + serviceLogs + "catalina.out";
            return catCommand;
        }


    }
}
