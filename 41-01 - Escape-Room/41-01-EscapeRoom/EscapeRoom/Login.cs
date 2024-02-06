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
    struct ColoredStringText
    {
        public string text;
        public ConsoleColor tileColor;

        public ColoredStringText(string _text = "", ConsoleColor _textColor = ConsoleColor.White)
        {
            text = _text;
            tileColor = _textColor;
        }
    }

    class Login
    {
        public static void StartGame()
        {
            StartScreen();
            LoginScreen();
        }

        private static void StartScreen()
        {
            //insert ASCII art
            Console.WriteLine("Welcome to my Escape Room!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void LoginScreen()
        {
            Console.WriteLine("Welcome brave adventurer! Please, tell me your name:");
            string player = new (value: Console.ReadLine().Trim());
            
            Console.WriteLine($"\nHello {player}! And be welcome to my little Escape Room!\n");

            ColoredStringText key = new("<K>", ConsoleColor.DarkYellow);
            ColoredStringText door = new("<D>", ConsoleColor.Red);
            ColoredStringText playerChar = new("<P>", ConsoleColor.Blue);

            Console.WriteLine("To escape, you must pick up the key, open the door and go through it.");
            Console.WriteLine($"The key is represented by a yellow {key.text} and the door by a red {door.text}.");
            Console.WriteLine($"Your character is represented by a blue {playerChar.text}, which turns yellow as soon as you have picked up the key.");
            Console.WriteLine("You can move your character either with the W, A, S and D keys on your keyboard or with the arrow keys.\n");
            
            Console.WriteLine("Controls:");
            Console.WriteLine("Move Up:     W or Up Arrow");
            Console.WriteLine("Move Down:   S or Down Arrow");
            Console.WriteLine("Move Left:   A or Left Arrow");
            Console.WriteLine("Move Right:  D or Right Arrow");
            
            Console.ReadKey();
            Console.Clear();
        }

    }
}
