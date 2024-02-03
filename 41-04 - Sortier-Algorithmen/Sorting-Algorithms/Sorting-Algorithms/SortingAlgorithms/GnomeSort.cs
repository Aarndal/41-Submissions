using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    internal class GnomeSort : SortingAlgorithm
    {
        public override string Name
        {
            get => "Gnome Sort";
        }

        public static int[] SortAscending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            int i = 0;
            while (i < sortedArray.Length)
            {
                if (i == 0 || sortedArray[i - 1] <= sortedArray[i])
                    i++;
                else
                {
                    (sortedArray[i], sortedArray[i - 1]) = (sortedArray[i - 1], sortedArray[i]);
                    i--;
                }
            }

            return sortedArray;
        }

        public static int[] SortDescending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            int i = 0;
            while (i < sortedArray.Length)
            {
                if (i == 0 || sortedArray[i - 1] >= sortedArray[i])
                    i++;
                else
                {
                    (sortedArray[i], sortedArray[i - 1]) = (sortedArray[i - 1], sortedArray[i]);
                    i--;
                }
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
