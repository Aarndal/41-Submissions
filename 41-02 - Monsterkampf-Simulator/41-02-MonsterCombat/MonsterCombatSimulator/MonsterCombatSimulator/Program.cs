using System.Security.Cryptography.X509Certificates;

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

            // Gets the user's input for the first Monster Type.
            "Choose your first Monster Type: ".Write();
            string input01 = Console.ReadLine().Trim();

            // Checks if the user's input for the first monster's Monster Type is valid. If not, it asks the user to input a valid Monster Type.
            while (input01 != "Goblin" && input01 != "Orc" && input01 != "Troll")
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ConsoleEx.ClearCurrentConsoleLine();
                "Please choose a valid Monster Type (Goblin, Orc, or Troll): ".Write(ConsoleColor.DarkYellow);
                input01 = Console.ReadLine().Trim();
            }

            "\n".WriteLine();

            $"You chose a {input01}. Now set the stats of the {input01}:".WriteLine();

            // Gets the user's input for the first Monster Type's stats.
            "Hit Points: ".Write();
            float hp01 = float.Parse(Console.ReadLine().Trim());
            "Attack Power: ".Write();
            float ap01 = float.Parse(Console.ReadLine().Trim());
            "Defense Points: ".Write();
            float dp01 = float.Parse(Console.ReadLine().Trim());
            "Speed: ".Write();
            float s01 = float.Parse(Console.ReadLine().Trim());

            // Creates a new object of the Monster class with the user's input for the first Monster Type.
            Monster monster01;
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
            
            "Choose your second Monster Type: ".Write();
            string monster02 = Console.ReadLine().Trim();


            Console.ReadKey();
        }
    }
}