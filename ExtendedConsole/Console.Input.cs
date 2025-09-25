// ReSharper disable CheckNamespace
using System.Runtime.Versioning;
using System.Text;

namespace ExtendedConsole;

// Extended from ConsoleBase
public static partial class Console
{
    [SupportedOSPlatform("windows")]
    public struct KeyOutput
    {
        public KeyOutput(ConsoleKey key, string? output)
        {
            Key = key;
            Output = output;
        }
        public KeyOutput() { }
        public ConsoleKey Key;
        public string? Output;
    }
    [SupportedOSPlatform("windows")]
    public static void Pause(string message = "Press any key to continue...", bool clearLine = true)
    {
        if (message.Contains('&')) message = Log.AddColors(message) ?? message;
        Write($"{message}");
        ReadKey(true);
        if (clearLine) Write($"\r{new string(' ', message.Length)}\r");
        else WriteLine();
    }
    [SupportedOSPlatform("windows")]
    public static ConsoleKey ReadKey(string source, string message, KeyOutput[] keyOutputs)
    {
        // Get the acceptable keys from the keyOutputs
        List<ConsoleKey> acceptableKeys = keyOutputs.Select(ko => ko.Key).ToList();

        Log.Write(source, message, LogLevel.Input);
        ConsoleKey key = ConsoleKey.NoName;
        while (!acceptableKeys.Contains(key))
        {
            key = ReadKey(true).Key;
        }
        WriteLine(Log.AddColors(keyOutputs.First(ko => ko.Key == key).Output) + Log.R);
        return key;
    }
    [SupportedOSPlatform("windows")]
    public static string? ReadLine(string source, string message, bool hideInput = false)
    {
        Log.Write(source, message, LogLevel.Input);
        string? resultStr = null;
        Write(Log.ValueColor);
        resultStr = hideInput ? ReadLine2(true) : ReadLine();
        Write(Log.R);
        return resultStr;
    }
    [SupportedOSPlatform("windows")]
    private static string? ReadLine2(bool hideInput)
    {
        StringBuilder sb = new StringBuilder();
        if (hideInput) CursorVisible = false;
        while (true)
        {
            int ch = Read();
            if (ch == -1) break;
            
            if (ch is '\r' or '\n')
            {
                if (ch == '\r' && System.Console.In.Peek() == '\n')
                    Read();
                if (hideInput) CursorVisible = true;
                return sb.ToString();
            }
            if(hideInput) Write("\b");
            sb.Append((char)ch);
        }
        if (hideInput) CursorVisible = true;
        return sb.Length > 0 ? sb.ToString() : null;
    }
}
