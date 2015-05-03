using System.Runtime.InteropServices;

namespace ATM.Utility
{
    internal delegate void SignalHandler(ConsoleSignal consoleSignal);

    internal enum ConsoleSignal
    {
        CtrlC = 0,
        CtrlBreak = 1,
        Close = 2,
        LogOff = 5,
        Shutdown = 6
    }

    internal static class ConsoleHelper
    {
        [DllImport("Kernel32", EntryPoint = "SetConsoleCtrlHandler")]
        public static extern bool SetSignalHandler(SignalHandler handler, bool add);
    }
}
