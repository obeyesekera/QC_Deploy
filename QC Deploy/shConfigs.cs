using System;

namespace QC_Deploy
{
    partial class mainForm
    {
        private Boolean runSSH = true;

        private string webappsList = "webappsList.cfg";
        private string servicesList = "servicesList.cfg";
        private string serverList = "serverList.cfg";


        private string disconnectDialogTitle = "Confirm Disconnect";
        private string disconnectDialogMessage = "Do you want to DISCONNECT from Server?";
        
        private string backupDialogTitle = "Confirm Backup Files";
        private string backupDialogMessage = "Do you want to backup selected files?";

        private string deployDialogTitle = "Confirm Build Status";
        private string deployDialogMessage = "is Build completed on Release Manager?";

        private string cleanDialogTitle = "Confirm Delete Files";
        private string cleanpDialogMessage = "Do you want to clean backup files?";

    }
}
