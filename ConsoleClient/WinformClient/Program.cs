using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
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
                    IntPtr AnswerBytes;
                    IntPtr AnswerCount;

                    foreach (Process p in processes)
                    {
                        if (WTSQuerySessionInformationW(WTS_CURRENT_SERVER_HANDLE,
                                                       p.SessionId,
                                                       WTS_UserName,
                                                       out AnswerBytes,
                                                       out AnswerCount))
                        {
                            //string userName = Marshal.PtrToStringUni(AnswerBytes);
                            string userName = GetProcessOwner(p.Id);
                            if (Environment.UserName == userName)
                            {
                                MessageBox.Show(userName + " - " + Environment.UserName + " - Only 1 instance per user allowed");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Could not access Terminal Services Server.");
                        }
                    }

                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientForm(devMode));
        }



        //just use the current TS server context.
        internal static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;

        //the User Name is the info we want returned by the query.
        internal static int WTS_UserName = 5;

        [DllImport("Wtsapi32.dll")]
        public static extern bool WTSQuerySessionInformationW(
            IntPtr hServer,
            int SessionId,
            int WTSInfoClass,
            out IntPtr ppBuffer,
            out IntPtr pBytesReturned);

        /// Gets the process owner.
        static string GetProcessOwner(int processId)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection moCollection = moSearcher.Get();

            foreach (ManagementObject mo in moCollection)
            {
                string[] args = new string[] { string.Empty };
                int returnVal = Convert.ToInt32(mo.InvokeMethod("GetOwner", args));
                if (returnVal == 0)
                    return args[0];
            }

            return "N/A";
        }


    }
}
