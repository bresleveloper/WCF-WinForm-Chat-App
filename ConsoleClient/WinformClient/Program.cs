using System;
using System.Collections.Generic;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool devMode = false;
            if (args != null && args.Length > 0 && args[0] == "dev")
            {
                devMode = true;
            }

            Application.Run(new ClientForm(devMode));
        }
    }
}
