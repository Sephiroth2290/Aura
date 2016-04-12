using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Aura
{
    public class ProcessMemoryStream : Stream, IDisposable
    {
        private ProcessAccess access;
        private bool disposed;
        private IntPtr hProcess;

        public override bool CanRead
        {
            get
            {
                return (this.access & ProcessAccess.VmRead) > ProcessAccess.None;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return (this.access & (ProcessAccess.VmOperation | ProcessAccess.VmWrite)) > ProcessAccess.None;
            }
        }

        public override long Length
        {
            get
            {
                throw new NotSupportedException("Length is not supported.");
            }
        }

        public override long Position { get; set; }

        public int ProcessId { get; set; }

        public ProcessMemoryStream(int processId, ProcessAccess access)
        {
            this.access = access;
            this.ProcessId = processId;
            this.hProcess = Kernel32.OpenProcess(access, false, processId);
            if (this.hProcess == IntPtr.Zero)
                throw new ArgumentException("Unable to open the process.");
        }

        ~ProcessMemoryStream()
        {
            this.Dispose(false);
        }

        public override void Close()
        {
            if (this.disposed)
                throw new ObjectDisposedException("ProcessMemoryStream");
            if (this.hProcess != IntPtr.Zero)
            {
                Kernel32.CloseHandle(this.hProcess);
                this.hProcess = IntPtr.Zero;
            }
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (this.hProcess != IntPtr.Zero)
                {
                    Kernel32.CloseHandle(this.hProcess);
                    this.hProcess = IntPtr.Zero;
                }
                base.Dispose(disposing);
            }
            this.disposed = true;
        }

        public override void Flush()
        {
            throw new NotSupportedException("Flush is not supported.");
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (this.disposed)
                throw new ObjectDisposedException("ProcessMemoryStream");
            if (this.hProcess == IntPtr.Zero)
                throw new InvalidOperationException("Process is not open.");
            IntPtr num = Marshal.AllocHGlobal(count);
            if (num == IntPtr.Zero)
                throw new InvalidOperationException("Unable to allocate memory.");
            int bytesRead = 0;
            Kernel32.ReadProcessMemory(this.hProcess, (IntPtr)this.Position, num, count, out bytesRead);
            this.Position = this.Position + (long)bytesRead;
            Marshal.Copy(num, buffer, offset, count);
            Marshal.FreeHGlobal(num);
            return bytesRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (this.disposed)
                throw new ObjectDisposedException("ProcessMemoryStream");
            switch (origin)
            {
                case SeekOrigin.Begin:
                    this.Position = offset;
                    break;
                case SeekOrigin.Current:
                    this.Position = this.Position + offset;
                    break;
                case SeekOrigin.End:
                    throw new NotSupportedException("SeekOrigin.End not supported.");
            }
            return this.Position;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("Cannot set the length for this stream.");
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (this.disposed)
                throw new ObjectDisposedException("ProcessMemoryStream");
            if (this.hProcess == IntPtr.Zero)
                throw new InvalidOperationException("Process is not open.");
            IntPtr num = Marshal.AllocHGlobal(count);
            if (num == IntPtr.Zero)
                throw new InvalidOperationException("Unable to allocate memory.");
            Marshal.Copy(buffer, offset, num, count);
            int bytesWritten = 0;
            Kernel32.WriteProcessMemory(this.hProcess, (IntPtr)this.Position, num, count, out bytesWritten);
            this.Position = this.Position + (long)bytesWritten;
            Marshal.FreeHGlobal(num);
        }

        public override void WriteByte(byte value)
        {
            byte[] buffer = new byte[1];
            int index = 0;
            int num = (int)value;
            buffer[index] = (byte)num;
            int offset = 0;
            int count = 1;
            this.Write(buffer, offset, count);
        }

        public void WriteString(string value)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(value);
            this.Write(bytes, 0, bytes.Length);
        }
    }
}
