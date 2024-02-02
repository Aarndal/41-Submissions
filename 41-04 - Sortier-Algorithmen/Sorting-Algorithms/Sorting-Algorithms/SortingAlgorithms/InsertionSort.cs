using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    internal class InsertionSort : SortingAlgorithm
    {
        public override string Name
        {
            get => "Insertion Sort";
        }
        
        public static int[] SortAscending(int[] _array)
        {
            int[] sortedArray = _array;

            for (int i = 1; i < sortedArray.Length; i++)
            {
                int key = sortedArray[i];
                int j = i - 1;

                while(j >= 0 && sortedArray[j] > key)
                {
                    sortedArray[j + 1] = sortedArray[j];
                    j--;
                }
                sortedArray[j + 1] = key;
            }

            return sortedArray;
        }

        public static int[] SortDescending(int[] _array)
        {
            int[] sortedArray = _array;

            for (int i = 1; i < sortedArray.Length; i++)
            {
                int key = sortedArray[i];
                int j = i - 1;

                while (j >= 0 && sortedArray[j] < key)
                {
                    sortedArray[j + 1] = sortedArray[j];
                    j--;
                }
                sortedArray[j + 1] = key;
            }

            return sortedArray;
        }

        // To-Do: Implement SortZickZack
        public static int[] SortZickZack(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];

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
