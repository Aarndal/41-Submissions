using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

            tmp ??= "";

            return tmp;
        }

        private static void Main()
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
            string input01 = TextInput().Trim().ToUpper();

            // Checks if the user's input for the first Monster's Monster Type is valid. If not, it asks the user to input a valid Monster Type.
            while (input01 != Enum.GetName(Monster.MonsterType.GOBLIN) && input01 != Enum.GetName(Monster.MonsterType.ORC) && input01 != Enum.GetName(Monster.MonsterType.TROLL))
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ConsoleEx.ClearCurrentConsoleLine();
                "Please choose a valid Monster Type (Goblin, Orc, or Troll): ".Write(ConsoleColor.DarkYellow);
                input01 = TextInput().Trim().ToUpper();
            }

            Monster.MonsterType monsterType01 = Enum.Parse<Monster.MonsterType>(input01, true);
            Monster? monster01 = SetMonsterStats(monsterType01);
            "\n".Write();

            // Gets the user's input for the second Monster's Monster Type.
            "Choose your second Monster Type: ".Write();
            string input02 = TextInput().Trim().ToUpper();

            // Checks if the user's input for the second Monster's Monster Type is valid and if it is of the same Monster Type as the first one. If not, it asks the user to input a valid Monster Type.
            while ((input02 == input01) || (input02 != Enum.GetName(Monster.MonsterType.GOBLIN) && input02 != Enum.GetName(Monster.MonsterType.ORC) && input02 != Enum.GetName(Monster.MonsterType.TROLL)))
            {
                if (input02 == input01)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ConsoleEx.ClearCurrentConsoleLine();
                    "The second Monster must be of a different Type than the first one: ".Write(ConsoleColor.DarkYellow);
                    input02 = TextInput().Trim().ToUpper();
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ConsoleEx.ClearCurrentConsoleLine();
                    "Please choose a valid Monster Type (Goblin, Orc, or Troll):".Write(ConsoleColor.DarkYellow);
                    input02 = TextInput().Trim().ToUpper();
                }
            }

            Monster.MonsterType monsterType02 = Enum.Parse<Monster.MonsterType>(input02, true);
            Monster? monster02 = SetMonsterStats(monsterType02);

            "\n".Write();
            "Please, press any key to continue...".WriteLine();

            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(0, Console.CursorTop);

            // Writes the stats of the first Monster to the console.
            $"The stats of your {monster01?.Type} are:".WriteLine();
            monster01?.PrintStats();

            // Writes the stats of the second Monster to the console.
            "\n".Write();
            $"The stats of your {monster02?.Type} are:".WriteLine();
            monster02?.PrintStats();

            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(0, Console.CursorTop);

            Monster?[] combatans = new Monster[2];

            combatans[0] = monster01?.SP >= monster02?.SP ? monster01 : monster02; // Abkürzung für If Else Abfrage | if true -> monster01, if false -> monster02
            combatans[1] = monster01?.SP < monster02?.SP ? monster02 : monster01;

            int currentCombatant = 0;
            
            while(true)
            {
                combatans[currentCombatant]?.Attack(combatans[1 - currentCombatant]);
                if (combatans[1 - currentCombatant]?.IsDead == true)
                {
                    $"The combat is over! The {combatans[currentCombatant]?.Type} won!".WriteLine();
                    break;
                }
                currentCombatant = 1 - currentCombatant;
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

        private static Monster? SetMonsterStats(Monster.MonsterType _userInput)
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
            float sp = float.Parse(TextInput().Trim());

            // !!! To-Do: Check if the user's input for the Monster's stats is valid. If not, ask the user to input valid stats.

            // !!! To-DO convert string to Enum

            // Creates a new object of the Monster class with the user's input for the Monster Type.
            return CreateMonster(_userInput, hp, ap, dp, sp);
        }


        private static Monster? CreateMonster(Monster.MonsterType _type, float _hp, float _ap, float _dp, float _sp)
        {
            return _type switch
            {
                Monster.MonsterType.GOBLIN => new Goblin(_hp, _ap, _dp, _sp),
                Monster.MonsterType.ORC => new Orc(_hp, _ap, _dp, _sp),
                Monster.MonsterType.TROLL => new Troll(_hp, _ap, _dp, _sp),
                _ => null,
            };

            /*
            switch (_type)
            {
                case Monster.MonsterType.GOBLIN:
                    return new Goblin(_hp, _ap, _dp, _sp);
                case Monster.MonsterType.ORC:
                    return new Orc(_hp, _ap, _dp, _sp);
                case Monster.MonsterType.TROLL:
                    return new Troll(_hp, _ap, _dp, _sp);
                default:
                    return null;
            */
        }
    }
}