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
            Console.Write("Bitte gib an, wie viele zufällige Zahlen von 1 bis 100 generiert werden sollen: ");
            int count = int.Parse(Console.ReadLine() ?? string.Empty);
            int[] array = new int[count];
            
            Random rnd = new();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(100);
            }

            //int[] array = [5, 3, 6, 4, 1, 2, 7];

            Console.WriteLine("Unsortiert:");
            PrintArray(array);

            SortingAlgorithm[] sortingAlgorithms =
            [
                new BubbleSort(),
                new InsertionSort(),
                new GnomeSort(),
                new HeapSort(),
                new SelectionSort(),
            ];

            //HeapSort alogrithm = new();
            //alogrithm.Sort(array, SortingMethods.ZickZack);

            //DisplaySorting(array, SortingMethods.ZickZack, alogrithm);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            int selectSortingMethodIndex = 0;
            bool selection = true;

            //while (selection)
            //{
            //    switch (keyInfo.Key)
            //    {
            //        case ConsoleKey.A:
            //            selectSortingMethodIndex--;
            //            if (selectSortingMethodIndex < 0)
            //                selectSortingMethodIndex = sortingMethods.Length - 1;
            //            break;
            //        case ConsoleKey.D:
            //            selectSortingMethodIndex++;
            //            if (selectSortingMethodIndex > sortingMethods.Length - 1)
            //                selectSortingMethodIndex = 0;
            //            break;
            //        case ConsoleKey.Enter:

            //            selection = false;
            //            break;
            //    }

            //}

            Console.ReadKey();
        }

        private static void DisplaySorting(int[] _array, SortingMethods _method, SortingAlgorithm _algorithm)
        {
            Console.WriteLine($"{_method} nach {_algorithm.Name} sortiert:");
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
