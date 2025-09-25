// ReSharper disable once CheckNamespace

namespace ExtendedConsole;

/// <summary>
/// Specifies the severity of a message output to the console.
/// </summary>
public enum LogLevel
{
    Critical,
    Error,
    Warning,
    Info,
    Debug,
    Success,
    Fail,
    Input
}
/// <summary>
/// The configuration for the log class.
/// </summary>
public struct MessageConfig
{
    public MessageConfig(
        bool addShortcuts = true,
        bool addShortcutsToPrefix = true,
        bool appendReset = true,
        bool hideBlankLines = false,
        bool addPrefixToNewLines = true,
        bool addPrefix = true)
    {
        AddShortcuts = addShortcuts;
        AddShortcutsToPrefix = addShortcutsToPrefix;
        AppendReset = appendReset;
        HideBlankLines = hideBlankLines;
        AddPrefixToNewLines = addPrefixToNewLines;
        AddPrefix = addPrefix;
    }

    public MessageConfig()
    {
        AddShortcuts = true;
        AddShortcutsToPrefix = true;
        AppendReset = true;
        HideBlankLines = false;
        AddPrefixToNewLines = true;
        AddPrefix = true;
    }

    public bool AddShortcuts { get; set; }
    public bool AddShortcutsToPrefix { get; set; }
    public bool AppendReset { get; set; }
    public bool HideBlankLines { get; set; }
    public bool AddPrefixToNewLines { get; set; }
    public bool AddPrefix { get; set; }
}

public static partial class Console
{
    public static class Log
    {
        public const string R = "\x001B[0m";
        public static readonly string PrefixColor = EscColor(0.0f, 1.0f, 1.0f);
        public static readonly string WarningColor = EscColor(1.0f, 1.0f, 0.0f);
        public static readonly string ErrorColor = EscColor(1.0f, 0.0f, 0.0f);
        public static readonly string ValueColor = EscColor(0.0f, 0.53333333333f, 1.0f);
        public static readonly string GreenTextColor = EscColor(0.0f, 1.0f, 0.13333333333f);
        public static readonly string BlueTextColor = EscColor(0.0f, 0.33333333333f, 1.0f);

        public const string GenericTextColor = R;

        // Minecraft colors
        public static readonly string Color0 = EscColor(0.0f, 0.0f, 0.0f); // Black
        public static readonly string Color1 = EscColor(0.0f, 0.0f, 0.666667f); // Dark Blue
        public static readonly string Color2 = EscColor(0.0f, 0.666667f, 0.0f); // Dark Green
        public static readonly string Color3 = EscColor(0.0f, 0.666667f, 0.666667f); // Dark Aqua
        public static readonly string Color4 = EscColor(0.666667f, 0.0f, 0.0f); // Dark Red
        public static readonly string Color5 = EscColor(0.666667f, 0.0f, 0.666667f); // Dark Purple
        public static readonly string Color6 = EscColor(1.0f, 0.666667f, 0.0f); // Gold
        public static readonly string Color7 = EscColor(0.666667f, 0.666667f, 0.666667f); // Gray
        public static readonly string Color8 = EscColor(0.3333333f, 0.3333333f, 0.3333333f); // Dark Gray
        public static readonly string Color9 = EscColor(0.3333333f, 0.3333333f, 1.0f); // Blue
        public static readonly string ColorA = EscColor(0.3333333f, 1.0f, 0.3333333f); // Green
        public static readonly string ColorB = EscColor(0.3333333f, 1.0f, 1.0f); // Aqua
        public static readonly string ColorC = EscColor(1.0f, 0.3333333f, 0.3333333f); // Red
        public static readonly string ColorD = EscColor(1.0f, 0.3333333f, 1.0f); // Light Purple
        public static readonly string ColorE = EscColor(1.0f, 1.0f, 0.3333333f); // Yellow
        public static readonly string ColorF = EscColor(1.0f, 1.0f, 1.0f); // White
        public static readonly string StyleK = "\x001B[5m"; // Obfuscated (Jokes on you, it doesn't work!)
        public static readonly string StyleL = "\x001B[1m"; // Bold
        public static readonly string StyleM = "\x001B[9m"; // Strikethrough
        public static readonly string StyleN = "\x001B[4m"; // Underline
        public static readonly string StyleO = "\x001B[3m"; // Italic
        public static readonly string StyleR = "\x001B[0m\x001B[27m"; // Reset (All styles)
        public static readonly string ColorNegative = "\x001B[7m";
        public static readonly string ColorPositive = "\x001B[27m";

        public static void RegisterDefaultColorShortcuts()
        {
            // Register Minecraft colors, the prefix for each shortcut should be a symbol, such as & or §.
            RegisterColorShortcut("&0", Color0); // Black
            RegisterColorShortcut("&1", Color1); // Dark Blue
            RegisterColorShortcut("&2", Color2); // Dark Green 
            RegisterColorShortcut("&3", Color3); // Dark Aqua
            RegisterColorShortcut("&4", Color4); // Dark Red 
            RegisterColorShortcut("&5", Color5); // Dark Purple
            RegisterColorShortcut("&6", Color6); // Gold
            RegisterColorShortcut("&7", Color7); // Gray
            RegisterColorShortcut("&8", Color8); // Dark Gray 
            RegisterColorShortcut("&9", Color9); // Blue 
            RegisterColorShortcut("&a", ColorA); // Green
            RegisterColorShortcut("&b", ColorB); // Aqua
            RegisterColorShortcut("&c", ColorC); // Red
            RegisterColorShortcut("&d", ColorD); // Light Purple
            RegisterColorShortcut("&e", ColorE); // Yellow
            RegisterColorShortcut("&f", ColorF); // White
            RegisterColorShortcut("&k", StyleK); // Obfuscated
            RegisterColorShortcut("&l", StyleL); // Bold
            RegisterColorShortcut("&m", StyleM); // Strikethrough
            RegisterColorShortcut("&n", StyleN); // Underline
            RegisterColorShortcut("&o", StyleO); // Italic
            RegisterColorShortcut("&r", StyleR); // Reset
            RegisterColorShortcut("&v", ValueColor); // Value Color
            RegisterColorShortcut("&-", ColorNegative); // Negative
            RegisterColorShortcut("&+", ColorPositive); // Positive
        }

        /// <summary>
        /// A dictionary containing all the shortcuts for colors.
        /// Key is the shortcut, value is the escape code.
        /// </summary>
        public static Dictionary<string, string> ColorShortcuts = new();

        /// <summary>
        /// Registers a new shortcut for a color.
        /// </summary>
        /// <param name="shortcut">The shortcut text to replace with the escape code string.</param>
        /// <param name="r">Red value.</param>
        /// <param name="g">Green value.</param>
        /// <param name="b">Blue value.</param>
        public static void RegisterColorShortcut(string shortcut, float r, float g, float b) =>
            RegisterColorShortcut(shortcut, EscColor(r, g, b));

        /// <summary>
        /// Gets the escape code for a color shortcut.
        /// </summary>
        /// <param name="shortcut">The shortcut to get.</param>
        /// <param name="escapeCode">The escape code of the shortcut.</param>
        public static void GetColorShortcut(string shortcut, out string? escapeCode) =>
            ColorShortcuts.TryGetValue(shortcut, out escapeCode);

        public static string? AddColors(string? text)
        {
            if (text is null) return null;
            if (!text.Contains('&')) return text;
            foreach (var shortcut in ColorShortcuts)
            {
                // If the text before the shortcut is a ^, then it's an escape character, so don't replace it.
                // Otherwise, replace the shortcut with the escape code.
                if (text.Contains($"^{shortcut.Key}")) continue;
                text = text.Replace(shortcut.Key, shortcut.Value);
            }

            return text;
        }

        private static void RegisterColorShortcut(string shortcut, string escapeCode) =>
            ColorShortcuts.Add(shortcut, escapeCode);

        public static void WriteLine(string? source, string? message, LogLevel logLevel = LogLevel.Info,
            MessageConfig? config = null)
        {
            config ??= DefaultMessageConfig;
            // If the message is blank or null, don't log it.
            if (config.Value.HideBlankLines && string.IsNullOrWhiteSpace(message)) return;
            // Trim blank lines from the start and end of the message.
            if (config.Value.HideBlankLines) message = message?.Trim();
            string? prefixStr = GetPrefixString(source, logLevel);
            if (config.Value.AddShortcuts) message = AddColors(message);
            if (config.Value.AddShortcutsToPrefix) prefixStr = AddColors(prefixStr);
            if (config.Value.AddPrefixToNewLines) message = message?.Replace("\n", $"\n{prefixStr} ");
            string? text = config.Value.AddPrefix ? $"{prefixStr} {message}" : message;
            if (config.Value.AppendReset) text += R + ColorPositive;
            Console.Write(text + "\n");
        }
        public static void Write(string? source, string? message, LogLevel logLevel = LogLevel.Info,
            MessageConfig? config = null)
        {
            config ??= DefaultMessageConfig;
            // If the message is blank or null, don't log it.
            if (config.Value.HideBlankLines && string.IsNullOrWhiteSpace(message)) return;
            // Trim blank lines from the start and end of the message.
            if (config.Value.HideBlankLines) message = message?.Trim();
            string? prefixStr = GetPrefixString(source, logLevel);
            if (config.Value.AddShortcuts) message = AddColors(message);
            if (config.Value.AddShortcutsToPrefix) prefixStr = AddColors(prefixStr);
            if (config.Value.AddPrefixToNewLines) message = message?.Replace("\n", $"\n{prefixStr} ");
            string? text = config.Value.AddPrefix ? $"{prefixStr} {message}" : message;
            if (config.Value.AppendReset) text += R + ColorPositive;
            Console.Write(text);
        }


        public static void ErrorWriteLine(string? source, string? message, LogLevel logLevel = LogLevel.Error,
            MessageConfig? config = null)
        {
            config ??= DefaultMessageConfig;
            // If the message is blank or null, don't log it.
            if (config.Value.HideBlankLines && string.IsNullOrWhiteSpace(message)) return;
            // Trim blank lines from the start and end of the message.
            if (config.Value.HideBlankLines) message = message?.Trim();
            string? prefixStr = GetPrefixString(source, logLevel);
            if (config.Value.AddShortcuts) message = AddColors(message);
            if (config.Value.AddShortcutsToPrefix) prefixStr = AddColors(prefixStr);
            if (config.Value.AddPrefixToNewLines) message = message?.Replace("\n", $"\n{prefixStr} ");
            string? text = config.Value.AddPrefix ? $"{prefixStr} {message}" : message;
            if (config.Value.AppendReset) text += R + ColorPositive;
            Error.Write(text + "\n");
        }
        public static void ErrorWrite(string? source, string? message, LogLevel logLevel = LogLevel.Error,
            MessageConfig? config = null)
        {
            config ??= DefaultMessageConfig;
            // If the message is blank or null, don't log it.
            if (config.Value.HideBlankLines && string.IsNullOrWhiteSpace(message)) return;
            // Trim blank lines from the start and end of the message.
            if (config.Value.HideBlankLines) message = message?.Trim();
            string? prefixStr = GetPrefixString(source, logLevel);
            if (config.Value.AddShortcuts) message = AddColors(message);
            if (config.Value.AddShortcutsToPrefix) prefixStr = AddColors(prefixStr);
            if (config.Value.AddPrefixToNewLines) message = message?.Replace("\n", $"\n{prefixStr} ");
            string? text = config.Value.AddPrefix ? $"{prefixStr} {message}" : message;
            if (config.Value.AppendReset) text += R + ColorPositive;
            Error.Write(text);
        }

        public static string GetPrefixString(string? source, LogLevel logLevel)
        {
            string? color = logLevel switch
            {
                LogLevel.Critical => ErrorColor,
                LogLevel.Error => ErrorColor,
                LogLevel.Warning => WarningColor,
                LogLevel.Info => ColorB,
                LogLevel.Debug => EscColor(0.70f, 0.70f, 0.70f),
                LogLevel.Success => GreenTextColor,
                LogLevel.Fail => ErrorColor,
                LogLevel.Input => GreenTextColor,
                _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel,
                    $"The provided LogLevel {logLevel} is not valid.")
            };
            string prefixStr = logLevel switch
            {
                LogLevel.Critical => $"{PrefixColor}[{source} {color}Critical{PrefixColor}]{color}",
                LogLevel.Error => $"{PrefixColor}[{source} {color}Error{PrefixColor}]{color}",
                LogLevel.Warning => $"{PrefixColor}[{source} {color}Warning{PrefixColor}]{color}",
                LogLevel.Info => $"{PrefixColor}[{source} {color}Info{PrefixColor}]{R}",
                LogLevel.Debug => $"{PrefixColor}[{source} {color}Debug{PrefixColor}]{color}",
                LogLevel.Success => $"{PrefixColor}[{source} {color}Success{PrefixColor}]{R}",
                LogLevel.Fail => $"{PrefixColor}[{source} {color}Fail{PrefixColor}]{R}",
                LogLevel.Input => $"{PrefixColor}[{color}{source} Input{PrefixColor}]{R}",
                _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel,
                    "The provided LogLevel is not valid. (how are you even seeing this??)")
            };
            return prefixStr;
        }

        public static MessageConfig DefaultMessageConfig = new();
        
        public static bool Confirm(string title, string message)
        {
            Write(title, message + " ");
            // use ReadKey
            ConsoleKeyInfo key = ReadKey(true);
            while (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N)
            {
                key = ReadKey(true);
            }
            
            Console.WriteLine(key.Key == ConsoleKey.Y ? "YES" : "NO");
            
            return key.Key == ConsoleKey.Y;
        }
    }
}