using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator
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


        // TODO: Make this method more generic

        ///// <summary>
        ///// Method to add a slider. Takes in an int for the slider value, and two ints for the slider bounds. Returns a string.
        ///// </summary>
        ///// <param name="_optionVal"></param>
        ///// <param name="_mapBoundMin"></param>
        ///// <param name="_mapBoundMax"></param>
        ///// <returns></returns>
        //private static string RenderSettingSlider(int _optionVal, int _mapBoundMin, int _mapBoundMax)
        //{
        //    string optionValStr = _optionVal < 10 ? $"0{_optionVal}" : $"{_optionVal}"; // Add 0 infront of all numbers below 10 TODO
        //    string sliderSec = "═";
        //    string sliderStr = "";

        //    sliderStr += "■"; // Place "border" at start of slider

        //    // Build slider
        //    for (int i = _mapBoundMin; i <= _mapBoundMax; i++)
        //    {
        //        if (i == _optionVal)
        //        { // Add thumb to slider
        //            sliderStr += $"╣{optionValStr}╠";
        //        }
        //        else
        //        { // Fill rest of slider with slider-sections
        //            sliderStr += sliderSec;
        //        }
        //    }

        //    sliderStr += "■"; // Place "border" at end of slider

        //    return sliderStr;
        //}
    }
}
