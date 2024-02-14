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

        protected override void SortAscending(int[] _array)
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < _array.Length; j++)
                {
                    if (_array[j] < _array[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                    (_array[i], _array[minIndex]) = (_array[minIndex], _array[i]);
            }
        }

        #region Unused methods
        //protected override void SortDescending(int[] _array)
        //{
        //    for (int i = 0; i < _array.Length - 1; i++)
        //    {
        //        int maxIndex = i;

        //        for (int j = i + 1; j < _array.Length; j++)
        //        {
        //            if (_array[j] > _array[maxIndex])
        //                maxIndex = j;
        //        }

        //        if (maxIndex != i)
        //            (_array[i], _array[maxIndex]) = (_array[maxIndex], _array[i]);
        //    }
        //}

        //protected override void SortZigZag(int[] _array)
        //{
        //    for (int i = 0; i < _array.Length - 1; i++)
        //    {
        //        int minIndex = i;

        //        for (int j = i + 1; j < _array.Length; j++)
        //        {
        //            if (_array[j] < _array[minIndex])
        //                minIndex = j;
        //        }

        //        if (minIndex != i)
        //            (_array[i], _array[minIndex]) = (_array[minIndex], _array[i]);

        //        i++;

        //        int maxIndex = i;

        //        for (int j = i + 1; j < _array.Length; j++)
        //        {
        //            if (_array[j] > _array[maxIndex])
        //                maxIndex = j;
        //        }

        //        if (maxIndex != i)
        //            (_array[i], _array[maxIndex]) = (_array[maxIndex], _array[i]);
        //    }
        //}
        #endregion
    }
}
