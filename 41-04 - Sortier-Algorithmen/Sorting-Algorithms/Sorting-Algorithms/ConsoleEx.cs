using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    internal static class ConsoleEx
    {
        static ConsoleColor m_foreground = ConsoleColor.White;
        static ConsoleColor m_background = ConsoleColor.Black;

        public static void WriteLine(this string _string)
        {
            Console.WriteLine(_string);
        }
        public static void WriteLine(this string _string, ConsoleColor _color)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(_string);
            ResetColor();
        }

        public static void Write(this string _string)
        {
            Console.Write(_string);
        }
        public static void Write(this string _string, ConsoleColor _color)
        {
            Console.ForegroundColor = _color;
            Console.Write(_string);
            ResetColor();
        }
        private static void ResetColor()
        {
            Console.ForegroundColor = m_foreground;
            Console.BackgroundColor = m_background;
        }

        public static void SetColors(ConsoleColor _foreground, ConsoleColor _background)
        {
            m_foreground = _foreground;
            m_background = _background;
            ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// Method to clear the current console line and set the cursor to the beginning of the line.
        /// </summary>
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
