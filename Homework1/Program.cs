using Common;

namespace Homework1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int arraySize = 100;
            var array = Helpers.CreateArray(arraySize);
            Helpers.PrintArray(array);

            var searchElement = new Random().Next(arraySize);
            var result = Algorithms.BinarySearchByOrderedArray(array, searchElement);
            Console.WriteLine(result < 0
                ? $"Search element {searchElement} was not found"
                : $"Search element {searchElement} has {result} index of array");

            Console.WriteLine("");
            var minValue = Algorithms.FindMinValue(array);
            Console.WriteLine($"Min Value: {minValue}");

            Console.WriteLine("");
            var a = Helpers.CreateMatrix();
            var b = Helpers.CreateMatrix();
            var c = Algorithms.MatrixMultiplication(a, b);
            Helpers.PrintMatrixMultiplication(a,b,c);
        }
    }
}
