using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Aura.Server;

namespace Aura.ProcessRelated
{
    internal static class Kernel32
    {
        internal const int WM_HOTKEY = 786;

        [DllImport("kernel32.dll")]
        internal static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll")]
        internal static extern bool CreateProcess(string applicationName, string commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, ProcessCreationFlags creationFlags, IntPtr environment, string currentDirectory, ref StartupInfo startupInfo, out ProcessInformation processInfo);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(ProcessAccess access, bool inheritHandle, int processId);

        public static bool Peek(Process proc, int target, byte[] data)
        {
            return Kernel32.ReadProcessMemory(proc.Handle, target, data, data.Length, (byte)0);
        }

        public static bool Poke(Process proc, int target, byte[] data)
        {
            return Kernel32.WriteProcessMemory(proc.Handle, target, data, data.Length, (byte)0);
        }

        [DllImport("kernel32.dll")]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, [Out] byte[] lpBuffer, int nSize, byte lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr baseAddress, IntPtr buffer, int count, out int bytesRead);

        [DllImport("kernel32.dll")]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        internal static extern int ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        internal static extern WaitEventResult WaitForSingleObject(IntPtr hObject, int timeout);

        [DllImport("kernel32.dll")]
        internal static extern bool WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int nSize, byte lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr baseAddress, IntPtr buffer, int count, out int bytesWritten);
    }
}
