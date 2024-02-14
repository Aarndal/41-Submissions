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
        public static string? Player { get; private set; }
        
        /// <summary>
        /// Welcome screen and introduction to the game.
        /// </summary>
        public static void StartGame()
        {
            WelcomeScreen();
            LoginScreen();
        }

        /// <summary>
        /// Starts the welcome screen.
        /// </summary>
        private static void WelcomeScreen()
        {
            "Welcome to my little Escape Room!".WriteLine();
            "\n".Write();
            "Press any key to continue...".WriteLine(ConsoleColor.DarkGreen);
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Login screen to get the player's name as well as the room's width and length, and to explain the game.
        /// </summary>
        private static void LoginScreen()
        {
            "Welcome brave adventurer! Please, tell me your name:".WriteLine();
            Player = GetUserInput();

            $"\nHello {Player}! And be welcome to my little Escape Room!\n".WriteLine();

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
            Game.RoomWidth = (int)(ConsoleEx.GetValideNumberInput(Game.RoomWidthMin, Game.RoomWidthMax, $"Please enter the width of the room (min: {Game.RoomWidthMin}, max: {Game.RoomWidthMax}): ", ConsoleColor.DarkGreen) + 2);
            Game.RoomLength = (int)(ConsoleEx.GetValideNumberInput(Game.RoomLengthMin, Game.RoomLengthMax, $"Please enter the length of the room (min: {Game.RoomLengthMin}, max: {Game.RoomLengthMax}): ", ConsoleColor.DarkGreen) + 2);
            "\n".Write();

            Thread.Sleep(TimeSpan.FromSeconds(1.0));

            "Press any key to start the game...".WriteLine(ConsoleColor.DarkGreen);
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Gets the user's input, checks if it is not null, and returns it.
        /// </summary>
        /// <returns></returns>
        private static string GetUserInput()
        {
            do
            {
                string input = Console.ReadLine()!.Trim();

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
