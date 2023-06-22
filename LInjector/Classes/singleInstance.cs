using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public static class SingleInstanceChecker
    {
        private static Mutex mutex;
        private static bool isNewInstance;

        public static void CheckInstance()
        {
            bool createdNew;
            mutex = new Mutex(true, "LInjector", out createdNew);
            isNewInstance = createdNew;

            if (!isNewInstance)
            {
                Process currentProcess = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
                {
                    if (process.Id != currentProcess.Id)
                    {
                        process.CloseMainWindow();
                        process.WaitForExit();
                    }
                }
                Application.Exit();
                return;
            }

            Application.Run(new splashscr()); // You can remove the splashscreen by changing "splashscr" for "application"
            Console.Title = "LInjector";

            Release();
        }

        private static void Release()
        {
            if (mutex != null)
            {
                if (isNewInstance)
                {
                    mutex.ReleaseMutex();
                }
                mutex.Close();
                mutex = null;
            }
        }
    }
}