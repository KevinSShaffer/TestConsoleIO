using System;
using System.Text;

namespace TestConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHandler = new InputHandler();

            inputHandler.Start();
        }
    }

    public class InputHandler
    {
        private readonly StringBuilder sb = new StringBuilder();

        public int RowNumber { get; set; } = 1;

        public void Start()
        {
            Console.CursorTop = RowNumber;

            while (true)
            {
                var keyInfo = Console.ReadKey(true);

                if (keyInfo.KeyChar >= 32 && keyInfo.KeyChar <= 126)
                {
                    sb.Insert(Console.CursorLeft, keyInfo.KeyChar);
                    RedrawLine();
                    Console.CursorLeft++;
                }
                else
                {
                    HandleFunctionKeys(keyInfo.Key);
                }
            }
        }

        private void HandleFunctionKeys(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.Enter:
                    // post
                    break;
                case ConsoleKey.Escape:
                    // back in menu
                    break;
                case ConsoleKey.UpArrow:
                    // navigate menu
                    break;
                case ConsoleKey.DownArrow:
                    // navigate menu
                    break;
                case ConsoleKey.LeftArrow:
                    Console.CursorLeft--;
                    break;
                case ConsoleKey.RightArrow:
                    if (Console.CursorLeft < sb.Length)
                        Console.CursorLeft++;
                    break;
                case ConsoleKey.Backspace:
                    if (sb.Length > 0)
                        sb.Remove(--Console.CursorLeft, 1);

                    RedrawLine();
                    break;
                case ConsoleKey.Delete:
                    if (sb.Length > Console.CursorLeft)
                        sb.Remove(Console.CursorLeft, 1);

                    RedrawLine();
                    break;
                case ConsoleKey.Insert:
                    // toggle insert mode
                    break;
                case ConsoleKey.Tab:
                    // cycle between options
                    break;
                case ConsoleKey.Home:
                    Console.CursorLeft = 0;
                    break;
                case ConsoleKey.End:
                    Console.CursorLeft = sb.Length;
                    break;
                default:
                    break;
            }
        }

        private void RedrawLine()
        {
            int pos = Console.CursorLeft;

            Console.CursorVisible = false;
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, RowNumber);
            Console.Write(sb.ToString());
            Console.CursorLeft = pos;
            Console.CursorVisible = true;
        }
    }
}
