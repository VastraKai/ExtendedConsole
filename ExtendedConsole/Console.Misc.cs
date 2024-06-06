// ReSharper disable once CheckNamespace
namespace ExtendedConsole;

// Extended from ConsoleBase
public static partial class Console
{
    
    /// <summary>
    /// Clears the console below the specified y value.
    /// </summary>
    /// <param name="y">The y value to clear below.</param>
    public static void ClearBelow(int y)
    {
        int currentY = CursorTop;
        int consoleHeight = WindowHeight;
        for (int i = currentY; i < consoleHeight; i++)
        {
            SetCursorPosition(0, i);
            Write(new string(' ', WindowWidth));
        }
        SetCursorPosition(0, currentY);
    }
    
    /// <summary>
    /// A constant character to be used with escape codes.
    /// </summary>
    public const char Esc = '\x001B';

    /// <summary>
    /// escColor: Gets the escape code to set a foreground color, or reset the foreground color.
    /// </summary>
    /// <param name="r">The value to be used for Red</param>
    /// <param name="g">The value to be used for Green</param>
    /// <param name="b">The value to be used for Blue</param>
    /// <returns>Foreground color escape code.</returns>
    public static string EscColor(float r, float g, float b) // returns a foreground color escape code 
    {
        // (changes the foreground color based on red, green, and blue values)
        int red = (int)Math.Round((float)(255 * r));
        int green = (int)Math.Round((float)(255 * g));
        int blue = (int)Math.Round((float)(255 * b));
        return $"{Esc}[38;2;{red};{green};{blue}m";
    }

    /// <summary>
    /// Returns an escape code to set the foreground color to the specified color.
    /// </summary>
    /// <param name="r">Red value</param>
    /// <param name="g">Green value</param>
    /// <param name="b">Blue value</param>
    /// <returns>Foreground color escape code.</returns>
    public static string EscColor(int r, int g, int b) => $"{Esc}[38;2;{r};{g};{b}m";
    /// <summary>
    /// Switches to an alternative console buffer.
    /// </summary>
    public static void SwitchToAlternativeBuffer()
    {
        Write($"{Esc}[?1049h");
    } 

    /// <summary>
    /// Switches to the default console buffer.
    /// </summary>
    public static void SwitchToMainBuffer()
    {
        Write($"{Esc}[?1049l");
    }

    /// <summary>
    /// Waits for the user to press the enter key.
    /// </summary>
    public static void WaitForEnter(string message = "Press enter to continue...")
    {
        Console.Log.Write("Console", message, LogLevel.Input);
        ConsoleKey key = ConsoleKey.NoName;
        while (key != ConsoleKey.Enter)
        {
            key = ReadKey(true).Key;
        }
        string spaces = new string(' ', message.Length + 16); // adding 10 is for the prefix
        Write($"\r{spaces}\r");
    }
}