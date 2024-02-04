using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.SortingAlgorithms
{
    internal abstract class SortingAlgorithm
    {
        public enum SortingMethods
        {
            Aufsteigend,
            Absteigend,
            ZickZack,
        }

        public abstract string? Name { get; }

        protected abstract void SortAscending(int[] _array);

        protected void SortDescending(int[] _array)
        {
            this.SortAscending(_array);
            Array.Reverse(_array);
        }

        protected void SortZigZag(int[] _array)
        {
            this.SortAscending(_array);

            for (int i = 0; i < _array.Length; i++)
            {
                if (i % 2 == 0)
                    _array[i] = _array[i / 2];
                else
                    _array[i] = _array[_array.Length - 1 - i / 2];
            }
        }

        public void Sort(int[] _array, SortingMethods _method)
        {
            switch (_method)
            {
                case SortingMethods.Aufsteigend:
                    this.SortAscending(_array);
                    break;
                case SortingMethods.Absteigend:
                    this.SortDescending(_array);
                    break;
                case SortingMethods.ZickZack:
                    this.SortZigZag(_array);
                    break;
            }
        }
    }
}
