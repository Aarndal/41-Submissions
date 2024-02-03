using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sorting_Algorithms
{
    internal class BubbleSort : SortingAlgorithm
    {
        public override string Name => "Bubble Sort";
        
        public static int[] SortAscending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            for (int i = sortedArray.Length - 1; i > 0; i--) // -1 because the last value will be sorted automatically.
            {
                for (int j = 0; j < i; j++) // -1 because the last value will be sorted automatically. -i because the last i values are already sorted.
                {
                    if (sortedArray[j] > sortedArray[j + 1]) // if the current value is greater than the next value then swap them.
                        (sortedArray[j + 1], sortedArray[j]) = (sortedArray[j], sortedArray[j + 1]); // tuple to swap values (see https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0180)
                }
            }

            return sortedArray;
        }

        public static int[] SortDescending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            for (int i = sortedArray.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (sortedArray[j] < sortedArray[j + 1]) // if the current value is less than the next value then swap them
                        (sortedArray[j], sortedArray[j + 1]) = (sortedArray[j + 1], sortedArray[j]); // tuple to swap values (see https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0180)
                }
            }

            return sortedArray;
        }

        public static int[] SortZickZack(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            for (int i = sortedArray.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (sortedArray[j] < sortedArray[j + 1])
                            (sortedArray[j], sortedArray[j + 1]) = (sortedArray[j + 1], sortedArray[j]);
                    }
                    else
                    {
                        if (sortedArray[j] > sortedArray[j + 1])
                            (sortedArray[j], sortedArray[j + 1]) = (sortedArray[j + 1], sortedArray[j]);
                    }
                }
            }

            Array.Reverse(sortedArray);

            return sortedArray;
        }
    }
}
