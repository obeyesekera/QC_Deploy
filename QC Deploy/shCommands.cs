namespace QC_Deploy
{
    partial class mainForm
    {
        private string backupWebAppsMV(string webModule)
        {
            string mvCommand = "mv /opt/tomcat/webapps/" + webModule + " /opt/tomcat/webapps/bk_" + webModule;
            return mvCommand;
        }

        private string backupServicesMV(string appService)
        {
            string mvCommand = "mv /opt/tomcat/webapps/" + appService + ".war /opt/tomcat/webapps/bk/" + appService + ".war";
            return mvCommand;
        }

        private string backupServicesRM(string appService)
        {
            string rmCommand = "rm -rf /opt/tomcat/webapps/" + appService;
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
            string mvCommand = "rm -rf /opt/tomcat/webapps/" + webModule;
            return mvCommand;
        }

        private string touchServicesRM(string appService)
        {
            string mvCommand = "rm -rf /opt/tomcat/webapps/" + appService + ".war";
            return mvCommand;
        }

        private string touchWebAppsMV(string webModule)
        {
            string mvCommand = "mv /opt/tomcat/webapps/bk_" + webModule + " /opt/tomcat/webapps/" + webModule;
            return mvCommand;
        }

        private string touchServicesMV(string appService)
        {
            string mvCommand = "mv /opt/tomcat/webapps/bk/" + appService + ".war /opt/tomcat/webapps/" + appService + ".war";
            return mvCommand;
        }

        private string cleanWebAppsRM(string webModule)
        {
            string rmCommand = "rm -rf /opt/tomcat/webapps/bk_" + webModule;
            return rmCommand;
        }

        private string cleanServicesRM(string appService)
        {
            string rmCommand = "rm /opt/tomcat/webapps/bk/" + appService + ".war";
            return rmCommand;
        }

        private string cleanLogs()
        {
            string catCommand = "cat /dev/null > /opt/tomcat/logs/catalina.out";
            return catCommand;
        }

        
    }
}
