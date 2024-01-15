using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Combat_Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sets the title of the console window and the colors of the console.
            Console.Title = "Monster Combat Simulator";
            ConsoleEx.SetColors(ConsoleColor.Black, ConsoleColor.DarkGreen);

            // Writes the welcome message and waits for the user to press a key.
            "Welcome to the Monster Combat Simulator!".WriteLine();
            "Press any key to continue...".WriteLine();
            Console.ReadKey();
            Console.Clear();

            // Writes the instructions for the user.
            Console.SetCursorPosition(0, Console.CursorTop);
            "There are three Monster Types to choose from:".WriteLine();
            "1. Goblin".WriteLine();
            "2. Orc".WriteLine();
            "3. Troll \n".WriteLine();

            "Each Monster has certain stats:".WriteLine();
            "- Hit Points: They describe the monster's health. If the monster's health drops to 0 or below, it is dead.".WriteLine();
            "- Attack Power: This is the amount of damage the monster can deal to another monster per attack.".WriteLine();
            "- Defense Points: This is the amount of damage the monster can block from another monster's attack.".WriteLine();
            "- Speed: The higher the monster's speed, the more often it can attack per round. \n".WriteLine();

            "Following you can choose two different Monster Types to fight against each other.".WriteLine();

            // Gets the user's input for the first Monster's Monster Type.
            "Choose your first Monster Type: ".Write();
            string input01 = Console.ReadLine().Trim();

            // Checks if the user's input for the first Monster's Monster Type is valid. If not, it asks the user to input a valid Monster Type.
            while (input01 != "Goblin" && input01 != "Orc" && input01 != "Troll")
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ConsoleEx.ClearCurrentConsoleLine();
                "Please choose a valid Monster Type (Goblin, Orc, or Troll): ".Write(ConsoleColor.DarkYellow);
                input01 = Console.ReadLine().Trim();
            }

            $"You chose a {input01}. Now set the stats of the {input01}:".WriteLine();

            // Gets the user's input for the first Monster's stats.
            "Hit Points: ".Write();
            float hp01 = float.Parse(Console.ReadLine().Trim());
            "Attack Power: ".Write();
            float ap01 = float.Parse(Console.ReadLine().Trim());
            "Defense Points: ".Write();
            float dp01 = float.Parse(Console.ReadLine().Trim());
            "Speed: ".Write();
            float s01 = float.Parse(Console.ReadLine().Trim());

            // !!! ToDo: Check if the user's input for the first Monster's stats is valid. If not, ask the user to input valid stats.

            // Creates a new object of the Monster class with the user's input for the first Monster Type.
            Monster? monster01 = null;
            switch (input01)
            {
                case "Goblin":
                    monster01 = new Goblin(hp01, ap01, dp01, s01);
                    break;
                case "Orc":
                    monster01 = new Orc(hp01, ap01, dp01, s01);
                    break;
                case "Troll":
                    monster01 = new Troll(hp01, ap01, dp01, s01);
                    break;
            }


            // Gets the user's input for the second Monster's Monster Type.
            "Choose your second Monster Type: ".Write();
            string input02 = Console.ReadLine().Trim();


            // ??? IF Abfrage für MonsterType01 == MonsterType02 ???

            // Checks if the user's input for the second Monster's Monster Type is valid and if it is of the same Monster Type as the first one. If not, it asks the user to input a valid Monster Type.
            while (input02 != "Goblin" && input02 != "Orc" && input02 != "Troll" && input01 == input02)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ConsoleEx.ClearCurrentConsoleLine();
                "Please choose a valid Monster Type (Goblin, Orc, or Troll). The second Monster must be of a different Type than the first one: ".Write(ConsoleColor.DarkYellow);
                input02 = Console.ReadLine().Trim();
            }

            $"You chose a {input02}. Now set the stats of the {input02}:".WriteLine();

            // Gets the user's input for the second Monster's stats.
            "Hit Points: ".Write();
            float hp02 = float.Parse(Console.ReadLine().Trim());
            "Attack Power: ".Write();
            float ap02 = float.Parse(Console.ReadLine().Trim());
            "Defense Points: ".Write();
            float dp02 = float.Parse(Console.ReadLine().Trim());
            "Speed: ".Write();
            float s02 = float.Parse(Console.ReadLine().Trim());

            // !!! ToDo: Check if the user's input for the second Monster's stats is valid. If not, ask the user to input valid stats.

            // Creates a new object of the Monster class with the user's input for the second Monster Type.
            Monster? monster02 = null;
            switch (input02)
            {
                case "Goblin":
                    monster02 = new Goblin(hp02, ap02, dp02, s02);
                    break;
                case "Orc":
                    monster02 = new Orc(hp02, ap02, dp02, s02);
                    break;
                case "Troll":
                    monster02 = new Troll(hp02, ap02, dp02, s02);
                    break;
            }

            // Writes the stats of the first Monster to the console.
            "\n".WriteLine();
            $"The stats of your {input01} are:".WriteLine();
            monster01.PrintStats();

            //// Writes the stats of the second Monster to the console.
            //"\n".WriteLine();
            //$"The stats of your {input02} are:".WriteLine();
            //monster02.PrintStats();

            Console.ReadKey();
        }
    }
}