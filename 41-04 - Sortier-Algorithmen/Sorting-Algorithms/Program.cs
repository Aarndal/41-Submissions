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
        Manual,
        Random
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
            if (selectedArrayCreationMethod == ArrayCreationMethod.Manual)
                array = GetUserInputArray();
            else
                array = GetRandomArray();

            Console.WriteLine("\nUnsorted:");
            PrintArray(array);

            bool selection = true;
            SortingAlgorithm[] sortingAlgorithms =
            {
                new BubbleSort(),
                new InsertionSort(),
                new GnomeSort(),
                new HeapSort(),
                new SelectionSort(),
            };
            SortingAlgorithm? selectedSortingAlgorithm = null;
            int selectSortingAlgorithmIndex = 0;

            Console.WriteLine("Select a sorting algorithm with A and D and confirm with Enter:\n");

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
            SortingMethods selectedSortingMethod = SortingMethods.Ascending;
            int selectSortingMethodIndex = 0;

            Console.WriteLine("Select a sorting method with A and D and confirm with Enter:\n");

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

            Console.WriteLine("Press any key to exit the program...");
            Console.ReadKey();
            Environment.Exit(0);
        }


        #region Program methods
        private static void DisplaySortedArray(int[] _array, SortingMethods _method, SortingAlgorithm _algorithm)
        {
            Console.WriteLine($"Sorted {_method} using {_algorithm.Name}:");
            _algorithm.Sort(_array, _method);
            PrintArray(_array);
        }

        private static int[] GetRandomArray()
        {
            int arraySizeMinValue = 2;
            int arraySizeMaxValue = 100;
            int randomMinValue = -100;
            int randomMaxValue = 100;

            Console.WriteLine($"Please specify how many random integers (from {randomMinValue} to {randomMaxValue}) should be generated.");
            int arrayLength = (int)ConsoleEx.GetValideNumberInput(arraySizeMinValue, arraySizeMaxValue, $"Enter an integer from {arraySizeMinValue} to {arraySizeMaxValue} here: ");
            int[] array = new int[arrayLength];
            Random rnd = new();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(randomMinValue, randomMaxValue);
            }

            return array;
        }

        private static int[] GetUserInputArray()
        {
            int arraySizeMinValue = 2;
            int arraySizeMaxValue = 10;
            int[] array = new int[(int)ConsoleEx.GetValideNumberInput(arraySizeMinValue, arraySizeMaxValue, $"Please specify how many integers you want to enter (Min: {arraySizeMinValue} | Max: {arraySizeMaxValue}): ")];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (int)ConsoleEx.GetValideNumberInput(int.MinValue, int.MaxValue, $"{i + 1}. Integer: ");
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
            _selectedArrayCreationMethod = ArrayCreationMethod.Random;
            Console.WriteLine($"Please select whether you want to enter a series of numbers manually");
            Console.WriteLine($"or whether a random series of numbers should be generated:\n");

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