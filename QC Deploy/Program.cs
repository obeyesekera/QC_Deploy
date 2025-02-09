using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC_Deploy
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        /// // Mutex to ensure only one instance runs
        private static Mutex mutex = null;

        [STAThread]
        static void Main()
        {
            const string appName = "QC_Deploy";
            bool createdNew;

            // Create a new mutex and check if it is already created
            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                // If the mutex is already created, it means another instance is running
                MessageBox.Show("An instance of QC DEPLOY is already running.");
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());

            // Release the mutex when the application exits
            GC.KeepAlive(mutex);
        }
    }
}
