using Sorting_Algorithms.SortingAlgorithms;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Sorting_Algorithms.SortingAlgorithms.SortingAlgorithm;
using static System.Collections.Specialized.BitVector32;

namespace Sorting_Algorithms
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Sorting Algorithms";
            ConsoleEx.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            
            Console.Write("Bitte gib an, wie viele zufällige Zahlen von 1 bis 100 generiert werden sollen: ");
            int count = int.Parse(Console.ReadLine() ?? string.Empty);
            //int.TryParse(Console.ReadLine().Trim(), out int count) ? 0 : count;
            int[] array = new int[count];

            Random rnd = new();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 101);
            }

            Console.CursorVisible = false;
            Console.WriteLine("\nUnsortiert:");
            PrintArray(array);

            SortingAlgorithm[] sortingAlgorithms =
            [
                new BubbleSort(),
                new InsertionSort(),
                new GnomeSort(),
                new HeapSort(),
                new SelectionSort(),
            ];

            int selectSortingAlgorithmIndex = 0;
            bool selection = true;
            SortingAlgorithm? selectedSortingAlgorithm = null;

            Console.WriteLine("Wähle einen Sortieralgorithmus mit A und D und bestätige mit Enter:\n");

            while (selection && selectedSortingAlgorithm == null)
            {
                ConsoleEx.ClearCurrentConsoleLine();
                Console.WriteLine($"{sortingAlgorithms[selectSortingAlgorithmIndex].Name}");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        selectSortingAlgorithmIndex--;
                        if (selectSortingAlgorithmIndex < 0)
                            selectSortingAlgorithmIndex = sortingAlgorithms.Length - 1;
                        break;
                    case ConsoleKey.D:
                        selectSortingAlgorithmIndex++;
                        if (selectSortingAlgorithmIndex > sortingAlgorithms.Length - 1)
                            selectSortingAlgorithmIndex = 0;
                        break;
                    case ConsoleKey.Enter:
                        selectedSortingAlgorithm = sortingAlgorithms[selectSortingAlgorithmIndex];
                        selection = false;
                        break;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
            Console.WriteLine("\n");
            selection = true;

            int selectSortingMethodIndex = 0;
            SortingMethods[] sortingMethods = Enum.GetValues<SortingMethods>();
            SortingMethods selectedSortingMethod = SortingMethods.Aufsteigend;

            Console.WriteLine("Wähle eine Sortiermethode mit A und D und bestätige mit Enter:\n");

            while (selection)
            {
                ConsoleEx.ClearCurrentConsoleLine();
                Console.WriteLine($"{sortingMethods[selectSortingMethodIndex]}");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
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
                        selectedSortingMethod = sortingMethods[selectSortingMethodIndex];
                        selection = false;
                        break;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }

            Console.WriteLine("\n");

            if (selectedSortingAlgorithm != null)
                DisplaySorting(array, selectedSortingMethod, selectedSortingAlgorithm);

            Console.WriteLine("Drücke eine beliebige Taste, um das Programm zu beenden...");
            Console.ReadKey();
        }

        private static void DisplaySorting(int[] _array, SortingMethods _method, SortingAlgorithm _algorithm)
        {
            Console.WriteLine($"{_method} mit {_algorithm.Name} sortiert:");
            _algorithm.Sort(_array, _method);
            PrintArray(_array);
        }

        private static void PrintArray(int[] _array)
        {
            string print = "[";

            foreach (int number in _array)
            {
                print += number + "|";
            }

            print = print.Substring(startIndex: 0, print.Length - 1);
            print += "]";

            Console.WriteLine(print + '\n');
        }
    }
}
