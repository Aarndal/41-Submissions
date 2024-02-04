using Sorting_Algorithms.SortingAlgorithms;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace Sorting_Algorithms
{
    internal class Program
    {
        static void Main()
        {
            //Console.Write("Bitte gib an, wie viele zufällige Zahlen von 1 bis 100 generiert werden sollen: ");
            //int count = int.Parse(Console.ReadLine() ?? string.Empty);

            //int[] array = new int[count];
            //Random rnd = new();

            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = rnd.Next(100);
            //}

            int[] array = [5, 3, 6, 4, 1, 2];

            Console.WriteLine("\nUnsortiert:");
            DisplayArray(array);

            //DisplaySortingMethod("Aufsteigend", "Selection Sort");
            //DisplayArray(SelectionSort.SortAscending(array));

            //DisplaySortingMethod("Absteigend", "Selection Sort");
            //DisplayArray(SelectionSort.SortDescending(array));

            //DisplaySortingMethod("ZickZack", "Selection Sort");
            //DisplayArray(SelectionSort.SortZigZag(array));

            DisplaySortingMethod("Aufsteigend", "Bubble Sort");
            DisplayArray(BubbleSort.SortAscending(array));

            DisplaySortingMethod("Absteigend", "Bubble Sort");
            DisplayArray(BubbleSort.SortDescending(array));

            DisplaySortingMethod("ZickZack", "Bubble Sort");
            DisplayArray(BubbleSort.SortZigZag(array));

            //DisplaySortingMethod("Aufsteigend", "Insertion Sort");
            //DisplayArray(InsertionSort.SortAscending(array));

            //DisplaySortingMethod("Absteigend", "Insertion Sort");
            //DisplayArray(InsertionSort.SortDescending(array));

            //DisplaySortingMethod("ZickZack", "Insertion Sort");
            //DisplayArray(InsertionSort.SortZigZag(array));

            //DisplaySortingMethod("Aufsteigend", "Gnome Sort");
            //DisplayArray(GnomeSort.SortAscending(array));

            //DisplaySortingMethod("Absteigend", "Gnome Sort");
            //DisplayArray(GnomeSort.SortDescending(array));

            //DisplaySortingMethod("ZickZack", "Gnome Sort");
            //DisplayArray(GnomeSort.SortZigZag(array));

            //DisplaySortingMethod("Aufsteigend", "Heap Sort");
            //DisplayArray(HeapSort.SortAscending(array));

            //DisplaySortingMethod("Absteigend", "Heap Sort");
            //DisplayArray(HeapSort.SortDescending(array));

            //DisplaySortingMethod("ZickZack", "Heap Sort");
            //DisplayArray(HeapSort.SortZigZag(array));

            Console.WriteLine("Test:");
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
            string display = "[";

            foreach (int number in _array)
            {
                display += number + "|";
            }

            display = display.Substring(0, display.Length - 1);
            display += "]";

            Console.WriteLine(display + '\n');
        }
    }
}
