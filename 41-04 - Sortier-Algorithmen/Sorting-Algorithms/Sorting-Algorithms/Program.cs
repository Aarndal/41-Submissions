using System.Collections.Generic;

namespace Sorting_Algorithms
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Bitte gib an, wie viele zufällige Zahlen von 1 bis 100 generiert werden sollen: ");
            int count = int.Parse(Console.ReadLine() ?? string.Empty);

            int[] array = new int[count];
            Random rnd = new();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 101);
            }

            Console.WriteLine("\nUnsortiert:");
            DisplayArray(array);

            Console.WriteLine("\n\nAufsteigend sortiert:");
            //int[] ascendingArray = BubbleSort.SortAscending(array);
            DisplayArray(BubbleSort.SortAscending(array));

            Console.WriteLine("\n\nAbsteigend sortiert:");
            //int[] descendingArray = BubbleSort.SortDescending(array);
            DisplayArray(BubbleSort.SortDescending(array));

            Console.WriteLine("\n\nZickZack sortiert:");
            //int[] zickzackArray = BubbleSort.SortZickZack(array);
            DisplayArray(BubbleSort.SortZickZack(array));

            Console.ReadKey();
        }
        private static void DisplayArray(int[] _array)
        {
            foreach (int number in _array)
            {
                Console.Write(number + " ");
            }
        }
    }
}
