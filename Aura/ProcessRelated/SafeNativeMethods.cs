using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.ProcessRelated
{
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern SafeProcessHandle OpenProcess(SafeNativeMethods.ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool ReadProcessMemory(SafeProcessHandle hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, UIntPtr nSize, UIntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool WriteProcessMemory(SafeProcessHandle hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, UIntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        internal static extern UIntPtr VirtualQueryEx(SafeProcessHandle hProcess, IntPtr lpAddress, out SafeNativeMethods.MEMORY_BASIC_INFORMATION lpBuffer, UIntPtr dwLength);

        internal struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr allocationBase;
            public uint allocationProtect;
            public IntPtr baseAddress;
            public SafeNativeMethods.PageAccessFlags protect;
            public UIntPtr regionSize;
            public SafeNativeMethods.PageAccessFlags state;
            public SafeNativeMethods.PageAccessFlags type;
        }

        [Flags]
        internal enum PageAccessFlags : uint
        {
            PAGE_READWRITE = 4U,
            MEM_COMMIT = 4096U,
            MEM_PRIVATE = 131072U,
        }

        [Flags]
        internal enum ProcessAccessFlags : uint
        {
            PROCESS_VM_OPERATION = 8U,
            PROCESS_VM_READ = 16U,
            PROCESS_VM_WRITE = 32U,
            PROCESS_QUERY_INFORMATION = 1024U,
        }
    }
}
