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

        // To-Do: Implement SortZigZag
        public static int[] SortZigZag(int[] _array)
        {
            int[] tmpArray = SortAscending(_array);
            int[] sortedArray = new int[tmpArray.Length];

            for (int i = 0; i < tmpArray.Length; i++)
            {
                if (i % 2 == 0)
                    sortedArray[i] = tmpArray[i / 2];
                else
                    sortedArray[i] = tmpArray[tmpArray.Length - (i / 2) - 1];
            }

            //for(int i = 1; i < sortedArray.Length; i++)
            //{
            //    int elementToSort = sortedArray[i];
            //    int j = i;

            //    if (i % 2 == 0)
            //    {
            //        while (j > 0 && elementToSort < sortedArray[j - 1])
            //        {
            //            (sortedArray[j], sortedArray[j - 1]) = (sortedArray[j - 1], sortedArray[j]);
            //            j--;
            //        }
            //    }
            //    else
            //    {
            //        while (j > 0 && elementToSort > sortedArray[j - 1])
            //        {
            //            (sortedArray[j], sortedArray[j - 1]) = (sortedArray[j - 1], sortedArray[j]);
            //            j--;
            //        }
            //    }
            //    sortedArray[j] = elementToSort;
            //}

            return sortedArray;
        }
    }
}
