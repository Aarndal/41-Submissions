using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.SortingAlgorithms
{
    internal class HeapSort : SortingAlgorithm
    {
        public override string Name => "Heap Sort";

        protected override void SortAscending(int[] _array)
        {
            for (int i = _array.Length/2 - 1; i >= 0; i--)
            {
                Heapify(_array, _array.Length, i);
            }

            for(int i = _array.Length - 1; i >= 1; i--)
            {
                (_array[i], _array[0]) = (_array[0], _array[i]);

                Heapify(_array, i, 0);
            }
        }

        private static void Heapify(int[] _array, int _length, int _parentPos)
        {
            int largestPos = _parentPos;
            int leftChildPos = _parentPos * 2 + 1;
            int rightChildPos = _parentPos * 2 + 2;

            if (leftChildPos < _length && _array[leftChildPos] > _array[largestPos])
                largestPos = leftChildPos;

            if (rightChildPos < _length && _array[rightChildPos] > _array[largestPos])
                largestPos = rightChildPos;
            
            if (largestPos != _parentPos)
            {
                (_array[largestPos], _array[_parentPos]) = (_array[_parentPos], _array[largestPos]);

                Heapify(_array, _length, largestPos);
            }
        }
    }
}
