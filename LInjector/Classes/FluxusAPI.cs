using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

/*
 * 
 * ░▒█▀▀▀░█░░█░▒█░█░█░█░▒█░█▀▀░░░█▀▀▄░▒█▀▀█░▀█▀
 * ░▒█▀▀░░█░░█░▒█░▄▀▄░█░▒█░▀▀▄░░▒█▄▄█░▒█▄▄█░▒█░
 * ░▒█░░░░▀▀░░▀▀▀░▀░▀░░▀▀▀░▀▀▀░░▒█░▒█░▒█░░░░▄█▄
 *
 * Fluxus UWP API (https://fluxteam.net)
 * Provided by Fluxteam.
 */

namespace LInjector.Classes
{
    // Token: 0x02000006 RID: 6
    public static class FluxusAPI
    {
        // Token: 0x06000013 RID: 19
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint access, bool inhert_handle, int pid);

        // Token: 0x06000014 RID: 20
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        // Token: 0x06000015 RID: 21
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, IntPtr nSize, int lpNumberOfBytesWritten);

        // Token: 0x06000016 RID: 22
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        // Token: 0x06000017 RID: 23
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // Token: 0x06000018 RID: 24
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        // Token: 0x06000019 RID: 25
        [DllImport("Resources\\libs\\FluxteamAPI.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool run_script(IntPtr proc, int pid, string path, [MarshalAs(UnmanagedType.LPWStr)] string script);

        // Token: 0x0600001A RID: 26
        [DllImport("Resources\\libs\\FluxteamAPI.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool is_injected(IntPtr proc, int pid, string path);

        // Token: 0x0600001B RID: 27
        [DllImport("Resources\\libs\\FluxteamAPI.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool inject_dll(int pid, [MarshalAs(UnmanagedType.LPWStr)] string script);

        // Token: 0x0600001C RID: 28 RVA: 0x0000287C File Offset: 0x00000A7C
        private static FluxusAPI.Result r_inject(string dll_path)
        {
            FileInfo fileInfo = new FileInfo(dll_path);
            FileSecurity accessControl = fileInfo.GetAccessControl();
            SecurityIdentifier identity = new SecurityIdentifier("S-1-15-2-1");
            accessControl.AddAccessRule(new FileSystemAccessRule(identity, FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            fileInfo.SetAccessControl(accessControl);
            Process[] processesByName = Process.GetProcessesByName("Windows10Universal");
            bool flag = processesByName.Length == 0;
            FluxusAPI.Result result;
            if (flag)
            {
                result = FluxusAPI.Result.ProcNotOpen;
            }
            else
            {
                uint num = 0U;
                while ((ulong)num < (ulong)((long)processesByName.Length))
                {
                    Process process = processesByName[(int)num];
                    bool flag2 = FluxusAPI.pid != process.Id;
                    if (flag2)
                    {
                        IntPtr intPtr = FluxusAPI.OpenProcess(1082U, false, process.Id);
                        bool flag3 = intPtr == FluxusAPI.NULL;
                        if (flag3)
                        {
                            return FluxusAPI.Result.OpenProcFail;
                        }
                        IntPtr intPtr2 = FluxusAPI.VirtualAllocEx(intPtr, FluxusAPI.NULL, (IntPtr)((dll_path.Length + 1) * Marshal.SizeOf(typeof(char))), 12288U, 64U);
                        bool flag4 = intPtr2 == FluxusAPI.NULL;
                        if (flag4)
                        {
                            return FluxusAPI.Result.AllocFail;
                        }
                        byte[] bytes = Encoding.Default.GetBytes(dll_path);
                        int num2 = FluxusAPI.WriteProcessMemory(intPtr, intPtr2, bytes, (IntPtr)((dll_path.Length + 1) * Marshal.SizeOf(typeof(char))), 0);
                        bool flag5 = num2 == 0 || (long)num2 == 6L;
                        if (flag5)
                        {
                            return FluxusAPI.Result.Unknown;
                        }
                        bool flag6 = FluxusAPI.CreateRemoteThread(intPtr, FluxusAPI.NULL, FluxusAPI.NULL, FluxusAPI.GetProcAddress(FluxusAPI.GetModuleHandle("kernel32.dll"), "LoadLibraryA"), intPtr2, 0U, FluxusAPI.NULL) == FluxusAPI.NULL;
                        if (flag6)
                        {
                            return FluxusAPI.Result.LoadLibFail;
                        }
                        FluxusAPI.pid = process.Id;
                        FluxusAPI.phandle = intPtr;
                        return FluxusAPI.Result.Success;
                    }
                    else
                    {
                        bool flag7 = FluxusAPI.pid == process.Id;
                        if (flag7)
                        {
                            return FluxusAPI.Result.AlreadyInjected;
                        }
                        num += 1U;
                    }
                }
                result = FluxusAPI.Result.Unknown;
            }
            return result;
        }

        public static FluxusAPI.Result inject_custom()
        {
            FluxusAPI.Result result;
            try
            {
                bool flag = !File.Exists(FluxusAPI.dll_path);
                if (flag)
                {
                    result = FluxusAPI.Result.DLLNotFound;
                }
                else
                {
                    result = FluxusAPI.r_inject(FluxusAPI.dll_path);
                }
            }
            catch
            {
                result = FluxusAPI.Result.Unknown;
            }
            return result;
        }

        public static void inject()
        {
            switch (FluxusAPI.inject_custom())
            {
                case FluxusAPI.Result.DLLNotFound:
                    createThreadMsgBox.createMsgThread("Dynamic-Link Library were not found\n", "Injection Error | Fluxteam API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case FluxusAPI.Result.OpenProcFail:
                    createThreadMsgBox.createMsgThread("OpenProcFail failed\n", "Injection Error | Fluxteam API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case FluxusAPI.Result.AllocFail:
                    createThreadMsgBox.createMsgThread("AllocFail failed\n", "Injection Error | Fluxteam API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case FluxusAPI.Result.LoadLibFail:
                    createThreadMsgBox.createMsgThread("LoadLibFail failed\n", "Injection Error | Fluxteam API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case FluxusAPI.Result.ProcNotOpen:
                    createThreadMsgBox.createMsgThread("Failure to find Roblox UWP.\nMake sure you have Roblox from the Microsoft Store", "Injection Error | Fluxteam API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case FluxusAPI.Result.Unknown:
                    createThreadMsgBox.createMsgThread("Unknown Error\n", "Injection Error | Fluxteam API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        public static bool is_injected(int pid)
        {
            FluxusAPI.phandle = FluxusAPI.OpenProcess(1082U, false, pid);
            return FluxusAPI.is_injected(FluxusAPI.phandle, pid, FluxusAPI.dll_path);
        }

        public static bool run_script(int pid, string script)
        {
            FluxusAPI.pid = pid;
            FluxusAPI.phandle = FluxusAPI.OpenProcess(1082U, false, pid);
            bool flag = pid == 0;
            bool result;
            if (flag)
            {
                createThreadMsgBox.createMsgThread("Inject API First", "Fluxus | API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            else
            {
                bool flag2 = script == string.Empty;
                if (flag2)
                {
                    result = FluxusAPI.is_injected(pid);
                }
                else
                {
                    result = FluxusAPI.run_script(FluxusAPI.phandle, pid, FluxusAPI.dll_path, script);
                }
            }
            return result;
        }

        public static void create_files(string dll_path_)
        {
            bool flag = !File.Exists(dll_path_);
            if (flag)
            {
                createThreadMsgBox.createMsgThread("Failure when initalizing Fluxus API\nDLL path was invalid\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FluxusAPI.dll_path = dll_path_;
            string text = "";
            foreach (string text2 in Directory.GetDirectories(Environment.GetEnvironmentVariable("LocalAppData") + "\\Packages"))
            {
                bool flag2 = text2.Contains("ROBLOXCORPORATION");
                if (flag2)
                {
                    bool flag3 = Directory.GetDirectories(text2 + "\\AC").Any((string dir) => dir.Contains("Temp"));
                    if (flag3)
                    {
                        text = text2 + "\\AC";
                    }
                }
            }
            bool flag4 = text == "";
            if (!flag4)
            {
                try
                {
                    bool flag5 = Directory.Exists("workspace");
                    if (flag5)
                    {
                        Directory.Move("workspace", "old_workspace");
                    }
                    bool flag6 = Directory.Exists("autoexec");
                    if (flag6)
                    {
                        Directory.Move("autoexec", "old_autoexec");
                    }
                }
                catch
                {
                }
                string path = Path.Combine(text, "workspace");
                string path2 = Path.Combine(text, "autoexec");
                bool flag7 = !Directory.Exists(path);
                if (flag7)
                {
                    Directory.CreateDirectory(path);
                }
                bool flag8 = !Directory.Exists(path2);
                if (flag8)
                {
                    Directory.CreateDirectory(path2);
                }
            }
        }

        public static string dll_path;

        public static IntPtr phandle;

        public static int pid = 0;

        private static readonly IntPtr NULL = (IntPtr)0;

        public enum Result : uint
        {
            Success,
            DLLNotFound,
            OpenProcFail,
            AllocFail,
            LoadLibFail,
            AlreadyInjected,
            ProcNotOpen,
            Unknown
        }
    }
}