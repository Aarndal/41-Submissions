using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms
{
    internal class HeapSort : SortingAlgorithm
    {
        public override string Name => "Heap Sort";

        public static int[] SortAscending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);

            for (int i = sortedArray.Length/2 - 1; i >= 0; i--)
            {
                Heapify(sortedArray, sortedArray.Length, i);
            }

            for(int i = sortedArray.Length - 1; i >= 1; i--)
            {
                (sortedArray[i], sortedArray[0]) = (sortedArray[0], sortedArray[i]);

                Heapify(sortedArray, i, 0);
            }

            return sortedArray;
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

        public static int[] SortDescending(int[] _array)
        {
            int[] sortedArray = new int[_array.Length];
            _array.CopyTo(sortedArray, 0);
            sortedArray = SortAscending(sortedArray);
            Array.Reverse(sortedArray);
            
            return sortedArray;
        }
    }
}
