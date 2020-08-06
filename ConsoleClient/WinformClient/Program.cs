using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool devMode = false;
            if (args != null && args.Length > 0 && args[0] == "dev")
            {
                devMode = true;
            }


            if (devMode == false)
            {
                string proc = Process.GetCurrentProcess().ProcessName;
                // get the list of all processes by that name
                Process[] processes = Process.GetProcessesByName(proc);
                // if there is more than one process... => 1 is ME (da....)
                if (processes.Length > 1)
                {
                    MessageBox.Show("only one instance at a time");
                    return;
                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientForm(devMode));
        }
    }
}
