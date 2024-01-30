using System.Reflection.Metadata.Ecma335;

namespace _2309_41_01_EscapeRoom
{

    class Program
    {
        static void Main()
        {
            Console.Title = "Escape Room";

            Login Login = new();
            Login.StartGame();

            Game EscapeRoom = new ();
            EscapeRoom.RunGame();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Congratulations! You've escaped!... Or have you?...");
            Console.ReadKey();
        }
    }
}