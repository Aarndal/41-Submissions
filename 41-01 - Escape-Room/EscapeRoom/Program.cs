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

            "Or have you?...".WriteLine(ConsoleColor.DarkRed);

            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}