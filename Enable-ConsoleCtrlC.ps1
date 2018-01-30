$code = @"
using System;
using System.Reflection;
using System.Runtime.InteropServices;

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
"@
Add-Type -TypeDefinition $code -Language CSharp
[void][CtrlCEnabler]::EnableCtrlC()
