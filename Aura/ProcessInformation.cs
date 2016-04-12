using System;

namespace Aura
{
    internal struct ProcessInformation
    {
        public IntPtr ProcessHandle { get; set; }

        public IntPtr ThreadHandle { get; set; }

        public int ProcessId { get; set; }

        public int ThreadId { get; set; }
    }
}
