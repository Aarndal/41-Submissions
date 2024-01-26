using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
            while (true)
            {
                if (input02 != "Goblin" && input02 != "Orc" && input02 != "Troll")
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ConsoleEx.ClearCurrentConsoleLine();
                    "Please choose a valid Monster Type (Goblin, Orc, or Troll):".Write(ConsoleColor.DarkYellow);
                    input02 = TextInput().Trim();
                }
                else if (input02 == input01)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ConsoleEx.ClearCurrentConsoleLine();
                    "The second Monster must be of a different Type than the first one: ".Write(ConsoleColor.DarkYellow);
                    input02 = TextInput().Trim();
                }
                else
                    break;
            }

            Monster? monster02 = SetMonsterStats(input02);

            "\n".Write();
            "Please, press any key to continue...".WriteLine();

            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(0, Console.CursorTop);

            // Writes the stats of the first Monster to the console.
            $"The stats of your {monster01.Type} are:".WriteLine();
            if (monster01 is not null)
                monster01.PrintStats();

            // Writes the stats of the second Monster to the console.
            "\n".Write();
            $"The stats of your {monster02.Type} are:".WriteLine();
            if (monster02 is not null)
                monster02.PrintStats();

            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(0, Console.CursorTop);

            Monster firstFighter = monster01.S >= monster02.S ? monster01 : monster02; // Abkürzung für If Else Abfrage | if true -> monster01, if false -> monster02
            Monster secondFighter = monster01.S < monster02.S ? monster02 : monster01;

            while (!firstFighter.IsDead && !secondFighter.IsDead)
            {
                firstFighter.Attack(secondFighter);
                secondFighter.IsMonsterDead();
                if (secondFighter.IsDead)
                {
                    $"The {secondFighter} is dead!".WriteLine();
                    break;
                }

                secondFighter.Attack(firstFighter);
                firstFighter.IsMonsterDead();
                if (firstFighter.IsDead)
                {
                    $"The {firstFighter} is dead!".WriteLine();
                    break;
                }
            }
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
            "- Speed: Determines how fast a monster is. The monster with the higher speed will attack first. \n".WriteLine();

            "Following you can choose two different Monsters to fight against each other. The Monsters cannot be of the same Monster Type!".WriteLine();
            "\n".Write();
        }

        private static Monster? SetMonsterStats(string _userInput)
        {
            Monster? monster = null;

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

            // !!! To-Do: Check if the user's input for the Monster's stats is valid. If not, ask the user to input valid stats.

            // !!! To-DO convert string to Enum

            // Creates a new object of the Monster class with the user's input for the Monster Type.
            return monster = CreateMonster(_userInput, hp, ap, dp, s);
        }


        // !!! To-DO convert string to Enum
        private static Monster? CreateMonster(string _userInput)
        {
            switch (_userInput)
            {
                case "Goblin":
                    return new Goblin();
                case "Orc":
                    return new Orc();
                case "Troll":
                    return new Troll();
                default:
                    return null;
            }
        }
    }
}