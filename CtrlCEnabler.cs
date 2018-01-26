// LICENSE - The Unlicense

using System;
using System.Runtime.InteropServices;

// See also: 
// - https://docs.microsoft.com/en-us/windows/console/ctrl-c-and-ctrl-break-signals
// - https://docs.microsoft.com/en-us/windows/console/setconsolectrlhandler

public static class CtrlCEnabler
{
    private delegate bool PHANDLER_ROUTINE(UInt32 ctrlType);

    [DllImport("kernel32.dll")]
    private static extern bool SetConsoleCtrlHandler(PHANDLER_ROUTINE handlerRoutine, bool add);

    public static bool EnableCtrlC()
    {
        return SetConsoleCtrlHandler(null, false);
    }
}
