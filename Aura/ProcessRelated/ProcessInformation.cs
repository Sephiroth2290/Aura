using System;

namespace Aura.ProcessRelated
{
    internal struct ProcessInformation
    {
        public IntPtr ProcessHandle { get; set; }

        public IntPtr ThreadHandle { get; set; }

        public int ProcessId { get; set; }

        public int ThreadId { get; set; }
    }
}
