using Sorting_Algorithms.SortingAlgorithms;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using static Sorting_Algorithms.SortingAlgorithms.SortingAlgorithm;
using static System.Collections.Specialized.BitVector32;

namespace Sorting_Algorithms
{
    public enum ArrayCreationMethod : int
    {
        Zufällig,
        Händisch
    }

    internal class Program
    {
        static void Main()
        {
            Console.Title = "Sorting Algorithms";
            ConsoleEx.SetColors(ConsoleColor.White, ConsoleColor.DarkBlue);
            Console.CursorVisible = false;

            SelectArrayCreationMethod(out ArrayCreationMethod selectedArrayCreationMethod);

            Console.WriteLine('\n');

            int[] array;
            if (selectedArrayCreationMethod == ArrayCreationMethod.Händisch)
                array = GetUserInputArray();
            else
                array = GetRandomArray();

            Console.WriteLine("\nUnsortiert:");
            PrintArray(array);

            bool selection = true;
            SortingAlgorithm[] sortingAlgorithms =
            [
                new BubbleSort(),
                new InsertionSort(),
                new GnomeSort(),
                new HeapSort(),
                new SelectionSort(),
            ];
            SortingAlgorithm? selectedSortingAlgorithm = null;
            int selectSortingAlgorithmIndex = 0;

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
            SortingMethods[] sortingMethods = Enum.GetValues<SortingMethods>();
            SortingMethods selectedSortingMethod = SortingMethods.Aufsteigend;
            int selectSortingMethodIndex = 0;

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
                DisplaySortedArray(array, selectedSortingMethod, selectedSortingAlgorithm);

            Console.WriteLine("Drücke eine beliebige Taste, um das Programm zu beenden...");
            Console.ReadKey();
            Environment.Exit(0);
        }


        #region Program methods
        private static void DisplaySortedArray(int[] _array, SortingMethods _method, SortingAlgorithm _algorithm)
        {
            Console.WriteLine($"{_method} mit {_algorithm.Name} sortiert:");
            _algorithm.Sort(_array, _method);
            PrintArray(_array);
        }

        private static int[] GetRandomArray()
        {
            Console.WriteLine("Bitte gib an, wie viele zufällige ganze Zahlen (von -100 bis 100) generiert werden sollen.");
            int arrayLength = ConsoleEx.GetValideNumberInput("Gebe hierzu nachfolgend eine ganze Zahl von 2 bis 100 ein: ", 2, 100);
            int[] array = new int[arrayLength];
            Random rnd = new();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-100, 101);
            }

            return array;
        }

        private static int[] GetUserInputArray()
        {
            int[] array = new int[ConsoleEx.GetValideNumberInput("Bitte gib an, wie viele ganze Zahlen eingegeben werden sollen (Min: 2 | Max: 10): ", 2, 10)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ConsoleEx.GetValideNumberInput($"{i + 1}. Zahl: ", int.MinValue, int.MaxValue);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ConsoleEx.ClearCurrentConsoleLine();
            }

            return array;
        }

        private static void PrintArray(int[] _array)
        {
            string print = "[";

            foreach (int number in _array)
            {
                print += number + "|";
            }

            print = print[..^1]; // Substring()
            print += "]";

            Console.WriteLine(print + '\n');
        }
        
        private static void SelectArrayCreationMethod(out ArrayCreationMethod _selectedArrayCreationMethod)
        {
            bool selection = true;
            ArrayCreationMethod[] arrayCreationMethods = Enum.GetValues<ArrayCreationMethod>();
            int selectArrayCreationMethodIndex = 0;
            _selectedArrayCreationMethod = ArrayCreationMethod.Zufällig;
            Console.WriteLine($"Bitte wähle aus, ob du eine Zahlenreihe händisch eingeben möchtest");
            Console.WriteLine($"oder eine zufällige Zahlenreihe generiert werden soll:\n");

            while (selection)
            {
                ConsoleEx.ClearCurrentConsoleLine();
                Console.WriteLine($"{arrayCreationMethods[selectArrayCreationMethodIndex]}");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.A:
                        selectArrayCreationMethodIndex--;
                        if (selectArrayCreationMethodIndex < 0)
                            selectArrayCreationMethodIndex = arrayCreationMethods.Length - 1;
                        break;
                    case ConsoleKey.D:
                        selectArrayCreationMethodIndex++;
                        if (selectArrayCreationMethodIndex > arrayCreationMethods.Length - 1)
                            selectArrayCreationMethodIndex = 0;
                        break;
                    case ConsoleKey.Enter:
                        _selectedArrayCreationMethod = arrayCreationMethods[selectArrayCreationMethodIndex];
                        selection = false;
                        break;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }
        #endregion
    }
}
