// ReSharper disable once CheckNamespace

using System.Runtime.InteropServices;

namespace ExtendedConsole;
public static partial class Console
{
    public static class Config
    {
        public enum ConsoleVisibility
        {
            Hidden,
            Shown = 5
        }

        private const int StdOutputHandle = -11;
        private const int StdErrorHandle = -12;
        private const int StdInputHandle = -10;
        private const uint EnableVirtualTerminalProcessing = 4;
        private const uint DisableNewlineAutoReturn = 8;
        private const uint EnableExtendedFlags = 128;
        private const uint EnableProcessedOutput = 1;
        private const uint EnableWrapAtEolOutput = 2;
        private const uint EnableProcessedInput = 1;
        private const uint EnableLineInput = 2;
        private const uint EnableEchoInput = 4;
        private const uint EnableWindowInput = 8;
        private const uint EnableMouseInput = 16;
        private const uint EnableInsertMode = 32;
        private const uint EnableQuickEditMode = 64;
        private const uint EnableAutoPosition = 256;
        private const uint EnableVirtualTerminalInput = 512;
        

        /// <summary>
        /// Use this to set up the console for ANSI escape codes
        /// </summary>
        public static void SetupConsole()
        {
            SetError(System.Console.Error);
            SetOut(System.Console.Out);
            SetIn(System.Console.In);
            
            // If windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                #if !WINDOWS
                #else
                nint handle = Api.GetStdHandle(StdOutputHandle);
                Api.GetConsoleMode(handle, out uint mode);
                mode |= EnableVirtualTerminalProcessing;
                Api.SetConsoleMode(handle, mode);
                #endif
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
            }

            Log.RegisterDefaultColorShortcuts();
            
        }

        public static void HideConsole()
        {
#if !WINDOWS
#else
            nint handle = Api.GetConsoleWindow();
            Api.SetWindowState(handle, ConsoleVisibility.Hidden);
#endif
        }

        public static void ShowConsole()
        {
#if !WINDOWS
#else
            nint handle = Api.GetConsoleWindow();
            Api.SetWindowState(handle, ConsoleVisibility.Shown);
#endif
        }
    }
}
