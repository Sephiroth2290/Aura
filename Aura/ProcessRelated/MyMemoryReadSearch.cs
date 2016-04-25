using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.ProcessRelated
{
    public class MyMemoryReadSearch : IDisposable
    {
        private bool disposed;
        private SafeProcessHandle m_hProcess;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        public void OpenProcess(uint processId)
        {
            if (this.m_hProcess != null && !this.m_hProcess.IsClosed)
                this.m_hProcess.Dispose();
            this.m_hProcess = SafeNativeMethods.OpenProcess(SafeNativeMethods.ProcessAccessFlags.PROCESS_VM_OPERATION | SafeNativeMethods.ProcessAccessFlags.PROCESS_VM_READ | SafeNativeMethods.ProcessAccessFlags.PROCESS_VM_WRITE | SafeNativeMethods.ProcessAccessFlags.PROCESS_QUERY_INFORMATION, true, processId);
        }

        public byte[] ReadProcessMemory(IntPtr baseAddress, UIntPtr size)
        {
            byte[] lpBuffer = new byte[(ulong)size];
            if (this.disposed || this.m_hProcess.IsClosed || !SafeNativeMethods.ReadProcessMemory(this.m_hProcess, baseAddress, lpBuffer, size, UIntPtr.Zero))
                return (byte[])null;
            return lpBuffer;
        }

        public void WriteProcessMemory(IntPtr baseAddress, byte[] data)
        {
            SafeNativeMethods.WriteProcessMemory(this.m_hProcess, baseAddress, data, data.Length, UIntPtr.Zero);
        }

        public uint? SearchDAProcessMemory(uint searchItem)
        {
            uint num1 = 65536U;
            UIntPtr dwLength = (UIntPtr)((ulong)Marshal.SizeOf(typeof(SafeNativeMethods.MEMORY_BASIC_INFORMATION)));
            SafeNativeMethods.MEMORY_BASIC_INFORMATION lpBuffer;
            for (; !this.disposed && !this.m_hProcess.IsClosed && num1 < 2147418111U; num1 = (uint)(int)lpBuffer.baseAddress + (uint)lpBuffer.regionSize)
            {
                //UIntPtr num2 = (UIntPtr) SafeNativeMethods.VirtualQueryEx(this.m_hProcess, (IntPtr) ((long) num1), out lpBuffer, dwLength);
                UIntPtr num2 = SafeNativeMethods.VirtualQueryEx(m_hProcess, (IntPtr)num1, out lpBuffer, dwLength);
                if (lpBuffer.type == SafeNativeMethods.PageAccessFlags.MEM_PRIVATE && lpBuffer.state == SafeNativeMethods.PageAccessFlags.MEM_COMMIT && lpBuffer.protect == SafeNativeMethods.PageAccessFlags.PAGE_READWRITE)
                {
                    byte[] numArray;
                    if ((numArray = this.ReadProcessMemory(lpBuffer.baseAddress, lpBuffer.regionSize)) == null)
                        return new uint?();
                    uint num3 = 0U;
                    while (num3 < (uint)lpBuffer.regionSize)
                    {
                        if ((long)((int)numArray[(int)(uint)(UIntPtr)num3] + 256 * (int)numArray[(int)(uint)(UIntPtr)(num3 + 1U)] + 65536 * (int)numArray[(int)(uint)(UIntPtr)(num3 + 2U)]) == (long)searchItem)
                            return new uint?((uint)(int)lpBuffer.baseAddress + num3);
                        num3 += 4U;
                    }
                }
            }
            return new uint?();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            if (disposing && this.m_hProcess != null)
                this.m_hProcess.Dispose();
            this.disposed = true;
        }
    }
}
