using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sorting_Algorithms
{
    internal class InsertionSort : SortingAlgorithm
    {
        public override string Name => "Insertion Sort";

        public static int[] SortAscending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            for (int i = 1; i < sortedArray.Length; i++)
            {
                int elementToSort = sortedArray[i];
                int j = i;

                while (j > 0 && elementToSort < sortedArray[j - 1])
                {
                    sortedArray[j] = sortedArray[j - 1];
                    j--;
                }
                sortedArray[j] = elementToSort;
            }

            return sortedArray;
        }

        public static int[] SortDescending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            for (int i = 1; i < sortedArray.Length; i++)
            {
                int elementToSort = sortedArray[i];
                int j = i;

                while (j > 0 && elementToSort > sortedArray[j - 1])
                {
                    sortedArray[j] = sortedArray[j - 1];
                    j--;
                }
                sortedArray[j] = elementToSort;
            }

            return sortedArray;
        }

        // To-Do: Implement SortZickZack
        public static int[] SortZickZack(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            sortedArray = SortAscending(sortedArray);

            for (int i = sortedArray.Length - 1; i > 0; i--)
            {
                int elementToSort = sortedArray[i];

                for (int j = i; j < length; j++)
                {

                }
                sortedArray[j] = elementToSort;
            }

            return sortedArray;
        }
    }
}
