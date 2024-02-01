using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    internal class BubbleSort
    {
        public static int[] SortAscending(int[] _array)
        {
            int[] sortedArray = _array;

            for (int i = 0; i < _array.Length - 1; i++) // -1 because the last value will be sorted automatically.
            // for (int i = _array.Length - 1; i > 0; i--) // descending
            {
                for (int j = 0; j < _array.Length - 1 - i; j++) // -1 because the last value will be sorted automatically. -i because the last i values are already sorted.
                // for (int j = 0; j < i; j++) // descending
                {
                    if (_array[j] > _array[j + 1]) // if the current value is greater than the next value then swap them.
                    {
                        (_array[j + 1], _array[j]) = (_array[j], _array[j + 1]); // tuple to swap values (see https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0180)
                    }
                }
            }

            return sortedArray;
        }

        public static int[] SortDescending(int[] _array)
        {
            int[] sortedArray = _array;

            for (int i = 0; i < _array.Length - 1; i++)
            {
                for (int j = 0; j < _array.Length - 1 - i; j++)
                {
                    if (_array[j] < _array[j + 1]) // if the current value is less than the next value then swap them
                    {
                        (_array[j], _array[j + 1]) = (_array[j + 1], _array[j]); // tuple to swap values (see https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0180)
                    }
                }
            }

            return sortedArray;
        }

        public static int[] SortZickZack(int[] _array)
        {
            int[] sortedArray = new int [_array.Length];

            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (i % 2 != 0)
                    sortedArray[i] = _array[i / 2];
                else
                    sortedArray[i] = _array[_array.Length - 1 - (i / 2)];
            }

            return sortedArray;
        }
    }
}
