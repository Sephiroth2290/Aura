using System;

namespace Aura
{
    [Flags]
    public enum ProcessAccess
    {
        CreateProcess = 128,
        CreateThread = 2,
        DuplicateHandle = 64,
        None = 0,
        QueryInformation = 1024,
        QueryLimitedInformation = 4096,
        SetInformation = 512,
        SetQuota = 256,
        SuspendResume = 2048,
        Terminate = 1,
        VmOperation = 8,
        VmRead = 16,
        VmWrite = 32,
    }
}
