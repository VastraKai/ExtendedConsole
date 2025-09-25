// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using System.Text;
// ReSharper disable once CheckNamespace
// Console Base Class (from System.Console)
// This class is used to provide a partial implementation of the Console class to be extended.

namespace ExtendedConsole; 

public static partial class Console
{
    
    public static TextReader In => System.Console.In;

    public static Encoding InputEncoding
    {
        get => System.Console.InputEncoding;
        set => System.Console.InputEncoding = value;
    }
    public static Encoding OutputEncoding
    {
        get => System.Console.OutputEncoding;
        set => System.Console.OutputEncoding = value;
    }
    public static bool KeyAvailable => System.Console.KeyAvailable;

    public static ConsoleKeyInfo ReadKey() => System.Console.ReadKey(false);
    public static ConsoleKeyInfo ReadKey(bool intercept) => System.Console.ReadKey(intercept);

    public static TextWriter Out => System.Console.Out;

    public static TextWriter Error => System.Console.Error;

    public static bool IsInputRedirected => System.Console.IsInputRedirected;

    public static bool IsOutputRedirected => System.Console.IsOutputRedirected;

    public static bool IsErrorRedirected => System.Console.IsErrorRedirected;

    [SupportedOSPlatform("windows")]
    public static int CursorSize
    {
        get => System.Console.CursorSize;
        set => System.Console.CursorSize = value;
    }
    [SupportedOSPlatform("windows")]
    public static bool NumberLock => System.Console.NumberLock;
    [SupportedOSPlatform("windows")]
    public static bool CapsLock => System.Console.CapsLock;

    public static ConsoleColor BackgroundColor
    {
        get => System.Console.BackgroundColor;
        set => System.Console.BackgroundColor = value;
    }
    public static ConsoleColor ForegroundColor
    {
        get => System.Console.ForegroundColor;
        set => System.Console.ForegroundColor = value;
    }
    public static void ResetColor() => System.Console.ResetColor();
    [SupportedOSPlatform("windows")]
    public static int BufferWidth
    {
        get => System.Console.BufferWidth;
        set => System.Console.BufferWidth = value;
    }
    [SupportedOSPlatform("windows")]
    public static int BufferHeight
    {
        get => System.Console.BufferHeight;
        set => System.Console.BufferHeight = value;
    }
    [SupportedOSPlatform("windows")]
    public static void SetBufferSize(int width, int height)
    {
        System.Console.SetBufferSize(width, height);
    }
    [SupportedOSPlatform("windows")]
    public static int WindowLeft
    {
        get => System.Console.WindowLeft;
        set => System.Console.WindowLeft = value;
    }
    [SupportedOSPlatform("windows")]
    public static int WindowTop
    {
        get => System.Console.WindowTop;
        set => System.Console.WindowTop = value;
    }
    [SupportedOSPlatform("windows")]
    public static int WindowWidth
    {
        get => System.Console.WindowWidth;
        set => System.Console.WindowWidth = value;
    }
    [SupportedOSPlatform("windows")]
    public static int WindowHeight
    {
        get => System.Console.WindowHeight;
        set => System.Console.WindowHeight = value;
    }
    [SupportedOSPlatform("windows")]
    public static void SetWindowPosition(int left, int top) => System.Console.SetWindowPosition(left, top);
    [SupportedOSPlatform("windows")]
    public static void SetWindowSize(int width, int height) => System.Console.SetWindowSize(width, height);
    public static int LargestWindowWidth => System.Console.LargestWindowWidth;

    public static int LargestWindowHeight => System.Console.LargestWindowHeight;

    [SupportedOSPlatform("windows")]
    public static bool CursorVisible
    {
        get => System.Console.CursorVisible;
        set { try { System.Console.CursorVisible = value; } catch { } }
    }
    
    public static int CursorLeft
    {
        get => System.Console.GetCursorPosition().Left;
        set => System.Console.CursorLeft = value;
    }
    
    public static int CursorTop
    {
        get => System.Console.GetCursorPosition().Top;
        set => System.Console.CursorTop = value;
    }
    [SupportedOSPlatform("windows")]
    public static (int Left, int Top) GetCursorPosition() => System.Console.GetCursorPosition();
    [SupportedOSPlatform("windows")]
    public static string Title
    {

        get => System.Console.Title;
        set => System.Console.Title = value;
    }
    public static void Beep() => System.Console.Beep();
    [SupportedOSPlatform("windows")]
    public static void Beep(int frequency, int duration)
    {
        System.Console.Beep(frequency, duration);
    }
    [SupportedOSPlatform("windows")]
    public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop)
    {
        System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, ' ', ConsoleColor.Black, BackgroundColor);
    }
    [SupportedOSPlatform("windows")]
    public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
    {
        System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
    }
    public static void Clear()
    {
        System.Console.Clear();
    }
    public static void SetCursorPosition(int left, int top)
    {
        System.Console.SetCursorPosition(left, top);
    }
    public static event ConsoleCancelEventHandler? CancelKeyPress
    {
        add => System.Console.CancelKeyPress += value;
        remove => System.Console.CancelKeyPress -= value;
    }
    public static bool TreatControlCAsInput
    {
        get => System.Console.TreatControlCAsInput;
        set => System.Console.TreatControlCAsInput = value;
    }
    public static Stream OpenStandardInput()
    {
        return System.Console.OpenStandardInput();
    }
    public static Stream OpenStandardInput(int bufferSize)
    {
        return System.Console.OpenStandardInput(bufferSize);
    }
    public static Stream OpenStandardOutput()
    {
        return System.Console.OpenStandardOutput();
    }
    public static Stream OpenStandardOutput(int bufferSize)
    {
        return System.Console.OpenStandardOutput(bufferSize);
    }
    public static Stream OpenStandardError()
    {
        return System.Console.OpenStandardError();
    }
    public static Stream OpenStandardError(int bufferSize)
    {
        return System.Console.OpenStandardError(bufferSize);
    }
    public static void SetIn(TextReader newIn)
    {
        System.Console.SetIn(newIn);
    }
    public static void SetOut(TextWriter newOut)
    {
        System.Console.SetOut(newOut);
    }
    public static void SetError(TextWriter newError)
    {
        System.Console.SetError(newError);
    }
    public static int Read()
    {
        return System.Console.In.Read();
    }
    public static string? ReadLine()
    {
        return System.Console.In.ReadLine();
    }
    public static void WriteLine()
    {
        System.Console.WriteLine();
    }
    public static void WriteLine(bool value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(char value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(char[]? buffer)
    {
        System.Console.WriteLine(buffer);
    }
    public static void WriteLine(char[] buffer, int index, int count)
    {
        System.Console.WriteLine(buffer, index, count);
    }
    public static void WriteLine(decimal value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(double value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(float value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(int value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(uint value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(long value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(ulong value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(object? value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine(string? value)
    {
        System.Console.WriteLine(value);
    }
    public static void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
    {
        System.Console.WriteLine(format, arg0);
    }
    public static void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
    {
        System.Console.WriteLine(format, arg0, arg1);
    }
    public static void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
    {
        System.Console.WriteLine(format, arg0, arg1, arg2);
    }
    public static void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
    {
        System.Console.WriteLine(format, arg);
    }
    public static void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
    {
        System.Console.Write(format, arg0);
    }
    public static void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
    {
        System.Console.Write(format, arg0, arg1);
    }
    public static void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1, object? arg2)
    {
        System.Console.Write(format, arg0, arg1, arg2);
    }
    public static void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[]? arg)
    {
        System.Console.Write(format, arg);
    }
    public static void Write(bool value)
    {
        System.Console.Write(value);
    }
    public static void Write(char value)
    {
        System.Console.Write(value);
    }
    public static void Write(char[]? buffer)
    {
        System.Console.Write(buffer);
    }
    public static void Write(char[] buffer, int index, int count)
    {
        System.Console.Write(buffer, index, count);
    }
    public static void Write(double value)
    {
        System.Console.Write(value);
    }
    public static void Write(decimal value)
    {
        System.Console.Write(value);
    }
    public static void Write(float value)
    {
        System.Console.Write(value);
    }
    public static void Write(int value)
    {
        System.Console.Write(value);
    }
    public static void Write(uint value)
    {
        System.Console.Write(value);
    }
    public static void Write(long value)
    {
        System.Console.Write(value);
    }
    public static void Write(ulong value)
    {
        System.Console.Write(value);
    }
    public static void Write(object? value)
    {
        System.Console.Write(value);
    }
    public static void Write(string? value)
    {
        System.Console.Write(value);
    }
}
