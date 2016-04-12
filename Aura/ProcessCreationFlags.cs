using System;

namespace Aura
{
    [Flags]
    internal enum ProcessCreationFlags
    {
        BreakawayFromJob = 16777216,
        DebugOnlyThisProcess = 2,
        DebugProcess = 1,
        DefaultErrorMode = 67108864,
        DetachedProcess = 8,
        ExtendedStartupInfoPresent = 524288,
        InheritParentAffinity = 4096,
        NewConsole = 16,
        NewProcessGroup = 512,
        NoWindow = 134217728,
        PreserveCodeAuthZLevel = 33554432,
        ProtectedProcess = 262144,
        SeparateWowVdm = 2048,
        SharedWowVdm = InheritParentAffinity,
        Suspended = 4,
        UnicodeEnvironment = 1024,
    }
}
