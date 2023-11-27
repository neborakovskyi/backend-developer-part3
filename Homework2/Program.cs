using System.Diagnostics;
using Common;

namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arraySizes = new int[3] {5000, 25000, 50000};
            var stopWatch = new Stopwatch();

            foreach (var arraySize in arraySizes)
            {
                Console.WriteLine($"Array size: {arraySize}");

                Console.WriteLine("\tShell Sorting");
                var array = Helpers.CreateArray(arraySize, isRandom: true);
                stopWatch.Start();
                SortingAlgorithms.ShellSorting(array);
                stopWatch.Stop();
                Console.WriteLine($"\t\tTime: {stopWatch.ElapsedMilliseconds} ms");
                stopWatch.Reset();

                Console.WriteLine("\tBucket Sort");
                array = Helpers.CreateArray(arraySize, isRandom: true);
                stopWatch.Start();
                SortingAlgorithms.BucketSort(array);
                stopWatch.Stop();
                Console.WriteLine($"\t\tTime: {stopWatch.ElapsedMilliseconds} ms");
                stopWatch.Reset();

                Console.WriteLine("\tHeap Sort");
                array = Helpers.CreateArray(arraySize, isRandom: true);
                stopWatch.Start();
                SortingAlgorithms.HeapSort(array);
                stopWatch.Stop();
                Console.WriteLine($"\t\tTime: {stopWatch.ElapsedMilliseconds} ms");
                stopWatch.Reset();

                Console.WriteLine();
            }
        }
    }
}
/*
Array size: 5000
        Shell Sorting
                Count: 56224
                Time: 6 ms
        Bucket Sort
                Count: 19997
                Time: 12 ms
        Heap Sort
                Count: 7500
                Time: 10 ms

Array size: 25000
        Shell Sorting
                Count: 500935
                Time: 25 ms
        Bucket Sort
                Count: 99999
                Time: 10 ms
        Heap Sort
                Count: 37500
                Time: 44 ms

Array size: 50000
        Shell Sorting
                Count: 1182391
                Time: 67 ms
        Bucket Sort
                Count: 199999
                Time: 52 ms
        Heap Sort
                Count: 75000
                Time: 46 ms 
 */