using System.Reflection.Metadata.Ecma335;

namespace _2309_41_01_EscapeRoom
{

    internal class Program
    {
        static void Main()
        {
            Console.Title = "Escape Room";

            Login.StartGame();

            Game EscapeRoom = new();
            EscapeRoom.RunGame();

            "Congratulations! You've escaped!...".WriteLine(ConsoleColor.DarkGreen);
            Thread.Sleep(TimeSpan.FromSeconds(2.0));
            $"Or have you, {Login.Player}?...".WriteLine(ConsoleColor.DarkRed);

            Thread.Sleep(TimeSpan.FromSeconds(2.0));
            "\nPress any key to exit...".WriteLine(ConsoleColor.DarkGray);
            Console.ReadKey(true);
        }
    }
}