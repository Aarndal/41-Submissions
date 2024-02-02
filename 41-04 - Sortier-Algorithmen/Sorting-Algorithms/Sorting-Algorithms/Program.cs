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

            string[] sortingMethods = new string[]
            {
                "Aufsteigend", //=> SortAscending
                "Absteigend", //=> SortDescending
                "Zickzack" //=> SortZickZack
            };


            SortingAlgorithm[] sortingAlgorithms = new SortingAlgorithm[]
            {
                new BubbleSort(),
                new InsertionSort(),
                new GnomeSort()
            };

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            int selectSortingMethodIndex = 0;
            bool selection = true;

            while (selection)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        selectSortingMethodIndex--;
                        if (selectSortingMethodIndex < 0)
                            selectSortingMethodIndex = sortingMethods.Length - 1;
                        break;
                    case ConsoleKey.D:
                        selectSortingMethodIndex++;
                        if (selectSortingMethodIndex > sortingMethods.Length - 1)
                            selectSortingMethodIndex = 0;
                        break;
                    case ConsoleKey.Enter:

                        selection = false;
                        break;
                }

            }

            Console.ReadKey();
        }

        private static void DisplaySortingMethod(string _sort, string _sortingAlgorithm)
        {
            Console.WriteLine($"{_sort} nach {_sortingAlgorithm} sortiert:");
        }

        private static void DisplayArray(int[] _array)
        {
            foreach (int number in _array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine('\n');
        }
    }
}
