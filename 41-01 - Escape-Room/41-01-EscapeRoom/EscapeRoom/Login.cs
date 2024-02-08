using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _2309_41_01_EscapeRoom
{
    internal class Login
    {
        public static void StartGame()
        {
            StartScreen();
            LoginScreen();
        }

        private static void StartScreen()
        {
            "Welcome to my Escape Room!".WriteLine();
            "\n".Write();
            "Press any key to continue...".WriteLine(ConsoleColor.DarkGreen);
            Console.ReadKey();
            Console.Clear();
        }

        private static void LoginScreen()
        {
            

            "Welcome brave adventurer! Please, tell me your name:".WriteLine();
            string player = GetUserInput();

            $"\nHello {player}! And be welcome to my little Escape Room!\n".WriteLine();

            "To escape, you must pick up the key, open the door and go through it.".WriteLine();

            "The key is represented by a yellow ".Write();
            "<K>".Write(ConsoleColor.DarkYellow);
            " and the door by a red ".Write();
            "<D>".Write(ConsoleColor.Red);
            ".".WriteLine();
            "Your character is represented by a blue ".Write();
            "<P>".Write(ConsoleColor.DarkCyan);
            ", which turns into a yellow ".Write();
            "<P>".Write(ConsoleColor.DarkYellow);
            " as soon as you have picked up the key.".WriteLine();

            "You can move your character either with the W, A, S and D keys or with the arrow keys on your keyboard.\n".WriteLine();

            "Controls:".WriteLine();
            "Move Up:     W or Up Arrow".WriteLine();
            "Move Down:   S or Down Arrow".WriteLine();
            "Move Left:   A or Left Arrow".WriteLine();
            "Move Right:  D or Right Arrow".WriteLine();

            "\n".Write();
            Game.m_roomXValue = ConsoleEx.GetValideNumberInput("Please enter the width of the room (min: 5, max: 30): ", ConsoleColor.DarkGreen, 5, 30) + 2;
            Game.m_roomYValue = ConsoleEx.GetValideNumberInput("Please enter the length of the room (min: 5, max: 15): ", ConsoleColor.DarkGreen, 5, 15) + 2;
            "\n".Write();

            Thread.Sleep(TimeSpan.FromSeconds(1.0));

            "Press any key to start the game...".WriteLine(ConsoleColor.DarkGreen);
            Console.ReadKey();
            Console.Clear();
        }

        private static string GetUserInput()
        {
            do
            {
                string input = Console.ReadLine().Trim();

                if (input is null || input == "")
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ConsoleEx.ClearCurrentConsoleLine();
                }
                else
                    return input;

            } while (true);
        }
    }
}
