using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.SortingAlgorithms
{
    internal class BubbleSort : SortingAlgorithm
    {
        public override string Name => "Bubble Sort";

        protected override void SortAscending(int[] _array)
        {
            for (int i = _array.Length - 1; i > 0; i--) // -1 because the last value will be sorted automatically.
            {
                for (int j = 0; j < i; j++) // -1 because the last value will be sorted automatically. -i because the last i values are already sorted.
                {
                    if (_array[j] > _array[j + 1]) // if the current value is greater than the next value then swap them.
                        (_array[j + 1], _array[j]) = (_array[j], _array[j + 1]); // tuple to swap values (see https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0180)
                }
            }
        }

        #region Unused methods
        //protected override void SortDescending(int[] _array)
        //{
        //    for (int i = _array.Length - 1; i > 0; i--)
        //    {
        //        for (int j = 0; j < i; j++)
        //        {
        //            if (_array[j] < _array[j + 1])
        //                (_array[j], _array[j + 1]) = (_array[j + 1], _array[j]);
        //        }
        //    }
        //}

        //protected override void SortZigZag(int[] _array)
        //{
        //    if (_array.Length % 2 == 0)
        //    {
        //        for (int i = 0; i < _array.Length - 1; i++)
        //        {
        //            for (int j = _array.Length - 1; j > 0; j--)
        //            {
        //                if (i % 2 == 0)
        //                {
        //                    if (_array[j] < _array[j - 1])
        //                        (_array[j], _array[j - 1]) = (_array[j - 1], _array[j]);
        //                }
        //                else
        //                {
        //                    if (_array[j] > _array[j - 1])
        //                        (_array[j], _array[j - 1]) = (_array[j - 1], _array[j]);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < _array.Length - 1; i++)
        //        {
        //            for (int j = _array.Length - 1; j > 0; j--)
        //            {
        //                if (i % 2 == 0)
        //                {
        //                    if (_array[j] > _array[j - 1])
        //                        (_array[j], _array[j - 1]) = (_array[j - 1], _array[j]);
        //                }
        //                else
        //                {
        //                    if (_array[j] < _array[j - 1])
        //                        (_array[j], _array[j - 1]) = (_array[j - 1], _array[j]);
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
