using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator
{
    internal class GameManager
    {
        private static string TextInput()
        {
            string? tmp = Console.ReadLine();

            if (tmp is null)
                tmp = "";

            return tmp;
        }

        private static void Main(string[] args)
        {
            // Sets the title of the console window and the colors of the console.
            Console.Title = "Monster Combat Simulator";
            ConsoleEx.SetColors(ConsoleColor.Black, ConsoleColor.DarkGreen);

            // Writes the welcome message and waits for the user to press a key.
            "Welcome to the Monster Combat Simulator!".WriteLine();
            "Press any key to continue...".WriteLine();
            Console.ReadKey();
            Console.Clear();

            Console.SetCursorPosition(0, Console.CursorTop);
            // Writes the instructions for the user.
            MonsterCombatSimulatorInstructions();

            // Gets the user's input for the first Monster's Monster Type.
            "Choose your first Monster Type: ".Write();
            string input01 = TextInput().Trim();

            // Checks if the user's input for the first Monster's Monster Type is valid. If not, it asks the user to input a valid Monster Type.
            while (input01 != "Goblin" && input01 != "Orc" && input01 != "Troll")
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ConsoleEx.ClearCurrentConsoleLine();
                "Please choose a valid Monster Type (Goblin, Orc, or Troll): ".Write(ConsoleColor.DarkYellow);
                input01 = TextInput().Trim();
            }

            Monster? monster01 = SetMonsterStats(input01);
            "\n".Write();

            // Gets the user's input for the second Monster's Monster Type.
            "Choose your second Monster Type: ".Write();
            string input02 = TextInput().Trim();

            // ??? IF Abfrage für MonsterType01 == MonsterType02 ???

            // Checks if the user's input for the second Monster's Monster Type is valid and if it is of the same Monster Type as the first one. If not, it asks the user to input a valid Monster Type.
            while (input02 != "Goblin" && input02 != "Orc" && input02 != "Troll" && input01 != input02)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ConsoleEx.ClearCurrentConsoleLine();
                "Please choose a valid Monster Type (Goblin, Orc, or Troll).".Write(ConsoleColor.DarkYellow);
                "The second Monster must be of a different Type than the first one: ".Write(ConsoleColor.DarkYellow);
                input02 = TextInput().Trim();
            }

            Monster? monster02 = SetMonsterStats(input02);
            "\n".Write();

            // Writes the stats of the first Monster to the console.
            $"The stats of your {input01} are:".WriteLine();
            if (monster01 is not null)
                monster01.PrintStats();

            // Writes the stats of the second Monster to the console.
            "\n".WriteLine();
            $"The stats of your {input02} are:".WriteLine();
            if (monster02 is not null)
                monster02.PrintStats();

            Console.ReadKey();
        }

        private static void MonsterCombatSimulatorInstructions()
        {
            "There are three Monster Types to choose from:".WriteLine();
            "1. Goblin".WriteLine();
            "2. Orc".WriteLine();
            "3. Troll \n".WriteLine();

            "Each Monster has certain stats:".WriteLine();
            "- Hit Points: They describe the monster's health. If the monster's health drops to 0 or below, it is dead.".WriteLine();
            "- Attack Power: This is the amount of damage the monster can deal to another monster per attack.".WriteLine();
            "- Defense Points: This is the amount of damage the monster can block from another monster's attack.".WriteLine();
            "- Speed: The higher the monster's speed, the more often it can attack per round. \n".WriteLine();

            "Following you can choose two different Monsters to fight against each other. The Monsters cannot be of the same Monster Type!".WriteLine();
            "\n".Write();
        }

        private static Monster? SetMonsterStats(string _userInput)
        {
            $"You chose a {_userInput}. Now set the stats of the {_userInput}:".WriteLine();

            // Gets the user's input for the Monster's stats.
            "Hit Points: ".Write();
            float hp = float.Parse(TextInput().Trim());
            "Attack Power: ".Write();
            float ap = float.Parse(TextInput().Trim());
            "Defense Points: ".Write();
            float dp = float.Parse(TextInput().Trim());
            "Speed: ".Write();
            float s = float.Parse(TextInput().Trim());

            // !!! ToDo: Check if the user's input for the Monster's stats is valid. If not, ask the user to input valid stats.

            // Creates a new object of the Monster class with the user's input for the Monster Type.
            Monster? _monster = null;

            switch (_userInput)
            {
                case "Goblin":
                    _monster = new Goblin(hp, ap, dp, s);
                    break;
                case "Orc":
                    _monster = new Orc(hp, ap, dp, s);
                    break;
                case "Troll":
                    _monster = new Troll(hp, ap, dp, s);
                    break;
            }

            return _monster;
        }
    }
}