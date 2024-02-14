using Monster_Combat_Simulator.Monsters;
using System;
using System.Collections.Generic;
using System.Data;
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
                "Please choose a valid Monster Type (Goblin, Orc, or Troll): ".Write(ConsoleColor.White);
                input01 = TextInput().Trim().ToUpper();
            }

            // Parses the user's input for the first Monster's Monster Type and sets the stats of the first Monster.
            Monster.MonsterType monsterType01 = Enum.Parse<Monster.MonsterType>(input01, true);
            Monster monster01 = Monster.CreateMonster(monsterType01)!;
            $"You've chosen a {monster01.Type}. Now set the stats of the {monster01.Type}:".WriteLine();
            monster01.SetStats();

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
                    "The second Monster must be of a different Type than the first one: ".Write(ConsoleColor.White);
                    input02 = TextInput().Trim().ToUpper();
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ConsoleEx.ClearCurrentConsoleLine();
                    "Please choose a valid Monster Type (Goblin, Orc, or Troll): ".Write(ConsoleColor.White);
                    input02 = TextInput().Trim().ToUpper();
                }
            }

            // Parses the user's input for the second Monster's Monster Type and sets the stats of the second Monster.
            Monster.MonsterType monsterType02 = Enum.Parse<Monster.MonsterType>(input02, true);
            Monster monster02 = Monster.CreateMonster(monsterType02)!;
            $"You've chosen a {monster02.Type}. Now set the stats of the {monster02.Type}:".WriteLine();
            monster02.SetStats();

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

            // Determines which Monster has the higher Speed Points and sets the combatants accordingly.
            Monster?[] combatans = new Monster[2];
            combatans[0] = monster01?.SP >= monster02?.SP ? monster01 : monster02;
            combatans[1] = monster01?.SP >= monster02?.SP ? monster02 : monster01;

            
            // Combat loop.
            int currentCombatant = 0;

            int combatCounter = 1;

            while (true)
            {
                float hpBeforeAttack = combatans[1 - currentCombatant]?.HP ?? 0;
                combatans[currentCombatant]?.Attack(combatans[1 - currentCombatant]);
                float damage = hpBeforeAttack - (combatans[1 - currentCombatant]?.HP ?? 0);
                
                $"The {combatans[currentCombatant]?.Type} deals {damage} damage to the {combatans[1 - currentCombatant]?.Type}!".WriteLine();

                Thread.Sleep(TimeSpan.FromSeconds(1.5));

                $"The {combatans[1 - currentCombatant]?.Type} has {combatans[1 - currentCombatant]?.HP} HP left! \n".WriteLine();

                Thread.Sleep(TimeSpan.FromSeconds(1.5));

                if (combatans[1 - currentCombatant]?.IsDead == true)
                {
                    $"The combat is over! The {combatans[currentCombatant]?.Type} won!".WriteLine();
                    $"\nThe combat lasted {combatCounter} rounds.".WriteLine();
                    break;
                }

                currentCombatant = 1 - currentCombatant;
                combatCounter++;
            }

            "\n".Write();
            
            "Please, press any key to exit...".WriteLine();
            Console.ReadKey(true);
        }

        #region Methods
        /// <summary>
        /// Writes the instructions for the Monster Combat Simulator to the console.
        /// </summary>
        private static void MonsterCombatSimulatorInstructions()
        {
            "There are three Monster Types to choose from:".WriteLine();
            "1. Goblin".WriteLine();
            "2. Orc".WriteLine();
            "3. Troll \n".WriteLine();

            "Each Monster has certain stats:".WriteLine();
            "- Hit Points: They describe a monster's health. If a monster's health points drop to 0 or below, it is dead.".WriteLine();
            "- Attack Power: This is the amount of damage a monster can deal to another monster per attack.".WriteLine();
            "- Defense Points: This is the amount of damage a monster can block from another monster's attack.".WriteLine();
            "- Speed Points: Determines how fast a monster is. The monster with the higher speed will attack first. \n".WriteLine();

            "Following you can choose two different Monsters to fight against each other. The Monsters cannot be of the same Monster Type!".WriteLine();
            "\n".Write();
        }

        private static string TextInput()
        {
            string? tmp = Console.ReadLine();
            tmp ??= "";
            return tmp;
        }
        #endregion
    }
}