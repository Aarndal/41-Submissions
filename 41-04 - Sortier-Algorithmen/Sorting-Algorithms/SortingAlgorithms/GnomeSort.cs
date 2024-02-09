using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.SortingAlgorithms
{
    internal class GnomeSort : SortingAlgorithm
    {
        public override string Name => "Gnome Sort";

        protected override void SortAscending(int[] _array)
        {
            int i = 0;
            while (i < _array.Length)
            {
                if (i == 0 || _array[i - 1] <= _array[i])
                    i++;
                else
                {
                    (_array[i], _array[i - 1]) = (_array[i - 1], _array[i]);
                    i--;
                }
            }
        }

        #region Unused methods
        //protected override void SortDescending(int[] _array)
        //{
        //    int i = 0;
        //    while (i < _array.Length)
        //    {
        //        if (i == 0 || _array[i - 1] >= _array[i])
        //            i++;
        //        else
        //        {
        //            (_array[i], _array[i - 1]) = (_array[i - 1], _array[i]);
        //            i--;
        //        }
        //    }
        //}
        #endregion
    }
}
