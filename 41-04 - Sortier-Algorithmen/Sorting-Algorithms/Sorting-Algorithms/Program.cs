using System.Collections.Generic;

namespace Sorting_Algorithms
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Bitte gib an, wie viele zufällige Zahlen von 1 bis 100 generiert werden sollen: ");
            string? input = Console.ReadLine();

            int count = 0;
            if (input is not null)
                count = int.Parse(input);

            int[] array = new int[count];
            Random rnd = new();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 101);
            }

            Console.WriteLine("\nUnsortiert:");

            foreach (int number in array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine("\n\nAufsteigend sortiert:");

            int[] ascendingArray = BubbleSort.SortAscending(array);

            foreach (int number in ascendingArray)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine("\n\nAbsteigend sortiert:");

            int[] descendingArray = BubbleSort.SortDescending(array);

            foreach (int number in descendingArray)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine("\n\nZickZack sortiert:");

            int[] zickzackArray = BubbleSort.SortZickZack(array);

            foreach (int number in zickzackArray)
            {
                Console.Write(number + " ");
            }

            Console.ReadKey();
        }
    }
}
