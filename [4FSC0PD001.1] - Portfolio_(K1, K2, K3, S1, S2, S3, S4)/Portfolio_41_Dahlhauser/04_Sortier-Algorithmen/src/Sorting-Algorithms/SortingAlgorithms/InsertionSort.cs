using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.SortingAlgorithms
{
    internal class InsertionSort : SortingAlgorithm
    {
        public override string Name => "Insertion Sort";

        protected override void SortAscending(int[] _array)
        {
            for (int i = 1; i < _array.Length; i++)
            {
                int elementToSort = _array[i];
                int j = i;

                while (j > 0 && elementToSort < _array[j - 1])
                {
                    _array[j] = _array[j - 1];
                    j--;
                }
                _array[j] = elementToSort;
            }
        }

        #region Unused methods
        //protected override void SortDescending(int[] _array)
        //{
        //    for (int i = 1; i < _array.Length; i++)
        //    {
        //        int elementToSort = _array[i];
        //        int j = i;

        //        while (j > 0 && elementToSort > _array[j - 1])
        //        {
        //            _array[j] = _array[j - 1];
        //            j--;
        //        }
        //        _array[j] = elementToSort;
        //    }
        //}

        // SortZigZag method doesn't work as intended. Sorts in a zigzag pattern, but from the middle point of the array outwards.
        //protected override void SortZigZag(int[] _array)
        //{
        //    for (int i = 1; i < _array.Length; i++)
        //    {
        //        int elementToSort = _array[i];
        //        int j = i;

        //        if (i % 2 == 0)
        //        {
        //            while (j > 0 && elementToSort < _array[j - 1])
        //            {
        //                (_array[j], _array[j - 1]) = (_array[j - 1], _array[j]);
        //                j--;
        //            }
        //        }
        //        else
        //        {
        //            while (j > 0 && elementToSort > _array[j - 1])
        //            {
        //                (_array[j], _array[j - 1]) = (_array[j - 1], _array[j]);
        //                j--;
        //            }
        //        }
        //        _array[j] = elementToSort;
        //    }
        //}
        #endregion
    }
}
