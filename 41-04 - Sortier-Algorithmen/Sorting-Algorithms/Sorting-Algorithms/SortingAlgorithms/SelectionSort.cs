using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.SortingAlgorithms
{
    internal class SelectionSort : SortingAlgorithm
    {
        public override string Name => "Selection Sort";

        public static int[] SortAscending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < sortedArray.Length; j++)
                {
                    if (sortedArray[j] < sortedArray[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                    (sortedArray[i], sortedArray[minIndex]) = (sortedArray[minIndex], sortedArray[i]);
            }

            return sortedArray;
        }

        public static int[] SortDescending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < sortedArray.Length; j++)
                {
                    if (sortedArray[j] > sortedArray[maxIndex])
                        maxIndex = j;
                }

                if (maxIndex != i)
                    (sortedArray[i], sortedArray[maxIndex]) = (sortedArray[maxIndex], sortedArray[i]);
            }

            return sortedArray;
        }

        public static int[] SortZickZack(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < sortedArray.Length; j++)
                {
                    if (sortedArray[j] < sortedArray[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                    (sortedArray[i], sortedArray[minIndex]) = (sortedArray[minIndex], sortedArray[i]);

                i++;

                int maxIndex = i;

                for (int j = i + 1; j < sortedArray.Length; j++)
                {
                    if (sortedArray[j] > sortedArray[maxIndex])
                        maxIndex = j;
                }

                if (maxIndex != i)
                    (sortedArray[i], sortedArray[maxIndex]) = (sortedArray[maxIndex], sortedArray[i]);
            }

            return sortedArray;
        }
    }
}
