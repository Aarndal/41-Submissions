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
    class Player
    {
        public string playerName;

        public Player(string _playerName)
        {
            playerName = _playerName;
        }
    }

    class Login
    {
        public void StartGame()
        {
            StartScreen();
            LoginScreen();
        }

        private void StartScreen()
        {
            //insert ASCII art
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        private void LoginScreen()
        {
            Console.WriteLine("Welcome brave adventurer! Please, tell me your name:");
            Player player = new Player(Console.ReadLine());
            Console.WriteLine($"Hello {player}! And be welcome to my little Escape Room.");
            Console.WriteLine("To escape, you have to pick up the key and open the door.");
            Console.WriteLine($"Your character will be represented through a blue <P> that will turn yellow as soon you've picked up the key.");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
