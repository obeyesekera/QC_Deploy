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

        private string touchDialogTitle = "Confirm Touch Files";
        private string touchDialogMessage = "Do you want to touch backup files?";

        private string cleanDialogTitle = "Confirm Clean Files";
        private string cleanFileDialogMessage = "Do you want to clean backup files and logs?";
        private string cleanLogDialogMessage = "Do you want to clean log files?";

        private string closeDialogTitle = "App closing";
        private string closeDialogConfirmMessage = "Server Connected. Do you want to exit?";
        private string closeDialogWarningMessage = "Backup Files not cleaned. Do you want to exit?";
        private string closeDialogErrorMessage = "Selected files not deployed. Do you want to exit?";
    }
}
