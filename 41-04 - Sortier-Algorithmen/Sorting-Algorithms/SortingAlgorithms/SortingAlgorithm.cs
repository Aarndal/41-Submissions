﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.SortingAlgorithms
{
    internal abstract class SortingAlgorithm
    {
        public enum SortingMethods : int
        {
            Ascending,
            Descending,
            ZigZag,
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
            int[] tmpArray = new int[_array.Length];
            _array.CopyTo(tmpArray, 0);

            for (int i = 0; i < _array.Length; i++)
            {
                if (i % 2 == 0)
                    _array[i] = tmpArray[_array.Length - (i / 2) - 1];
                else
                    _array[i] = tmpArray[i / 2];
            }
        }

        public void Sort(int[] _array, SortingMethods _method)
        {
            switch (_method)
            {
                case SortingMethods.Ascending:
                    this.SortAscending(_array);
                    break;
                case SortingMethods.Descending:
                    this.SortDescending(_array);
                    break;
                case SortingMethods.ZigZag:
                    this.SortZigZag(_array);
                    break;
            }
        }
    }
}
