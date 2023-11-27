using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Homework2
{
    public static class SortingAlgorithms
    {
        public static void ShellSorting(int[] array)
        {
            var step = array.Length / 2;
            var count = 0;
            while (step > 0)
            {
                for (var i = 0; i < (array.Length - step); i++)
                {
                    var j = i;
                    while ((j >= 0) && (array[j] > array[j + step]))
                    {
                        Helpers.Swap(array, j, j + step);
                        j -= step;
                        count++;
                    }
                }
                step /= 2;
            }
            Console.WriteLine($"\t\tCount: {count}");
        }

        public static void BucketSort(int[] array)
        {
            var size = array.Length;
            var count = 0;

            if (size < 2)
            {
                return;
            }

            var maxValue = array[0];
            var minValue = array[0];

            for (var i = 1; i < size; i++)
            {
                count++;
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }

                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }
            
            var bucket = new List<int>[maxValue - minValue + 1];

            for (var i = 0; i < bucket.Length; i++)
            {
                count++;
                bucket[i] = new List<int>();
            }

            for (var i = 0; i < size; i++)
            {
                count++;
                bucket[array[i] - minValue].Add(array[i]);
            }

            var position = 0;
            for (var i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (var j = 0; j < bucket[i].Count; j++)
                    {
                        array[position] = bucket[i][j];
                        position++;
                        count++;
                    }
                }
            }
            Console.WriteLine($"\t\tCount: {count}");
        }

        public static void HeapSort(int[] array)
        {
            var count = BuildHeap(array);
            var heapSize = array.Length;
            while (heapSize > 1)
            {
                Helpers.Swap(array, 0, heapSize - 1);
                heapSize--;
                count += SiftDown(array, 0, heapSize);
                count++;
            }
            Console.WriteLine($"\t\tCount: {count}");
        }
        private static int BuildHeap(int[] array)
        {
            var heapSize = array.Length;
            var count = 0;
            for (var i = heapSize / 2; i >= 0; i--)
            {
                count += SiftDown(array, i, heapSize);
                count++;
            }

            return count;
        }
        private static int SiftDown(int[] array, int index, int heapSize)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var largest = index;
            var count = 0;

            if (left < heapSize && array[index] < array[left])
            {
                largest = left;
            }

            if (right < heapSize && array[largest] < array[right])
            {
                largest = right;
            }

            if (index != largest)
            {
                Helpers.Swap(array, index, largest);
                count += SiftDown(array, largest, heapSize);
            }
            return count;
        }
    }
}
