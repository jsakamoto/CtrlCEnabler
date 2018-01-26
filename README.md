# Ctrl+C Enabler for PowerShell

## Summary

This is a .NET class library that allows you to enable Ctrl+C break on PowerShell console, always.

## Why should be use this?

In some case, a PowerShell console, which is launched from Visual Studio IDE external tools menu, doesn't accept Ctrl+C.

This class library can fix it :)

## How to install in your PowerShell?

1. Download "CtrlCEnabler.dll" from [release page](releases), and save it into "%HOME%\Documents\WindowsPowerShell" folder.
2. Open the PowerShell console and enter the following command:
```powershell
PS> notepad $PROFILE
```
3. Then, the file "Microsoft.PowerShell_profile.ps1" is opened in a text editor.
4. Append lines as follows at the bottom of "Microsoft.PowerShell_profile.ps1", and save it.
```powershell
# Enable Ctrl+C force.
Add-Type -Path "$env:HOME\Documents\WindowsPowerShell\CtrlCEnabler.dll"
[CtrlCEnabler]::EnableCtrlC() > $null
```

After this instruction, the PowerShell console always enables Ctrl + C break, even when launched from Visual Studio's external tools menu.

## How does it work?

This class library just calls the `SetConsoleCtrlHandler` Win32 API.

```csharp
public static bool EnableCtrlC()
{
    return SetConsoleCtrlHandler(null, false);
}
```

See also:

- https://docs.microsoft.com/en-us/windows/console/ctrl-c-and-ctrl-break-signals
- https://docs.microsoft.com/en-us/windows/console/setconsolectrlhandler

## LICENSE

[The Unlicense](LICENSE)