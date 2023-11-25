using System.Drawing;
using System.Xml.Linq;

namespace Common
{
    public static class Helpers
    {
        public static int[] CreateArray(int size = 0, bool isEmpty = false, bool isRandom = false, bool isOrdered = false)
        {
            var array = new int[size];
            if (!isEmpty)
            {
                for (var i = 0; i < size; i++)
                {
                    array[i] = i + 1;
                }
            }

            if (isRandom && !isEmpty)
            {
                var rand = new Random();
                for (var i = 0; i < size; i++)
                {
                    array[i] = rand.Next(size);
                }
            }

            if (isOrdered && !isEmpty && isRandom)
            {
                Array.Sort(array);
            }

            return array;
        }

        public static void PrintArray(int[] array)
        {
            Console.WriteLine($"Array Item: ");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static int RowsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(0) + 1;
        }
        public static int ColumnsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }

        public static int[,] CreateMatrix(int n = 3, int m = 3)
        {
            var matrix = new int[n, m];
            var rand = new Random();
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    //Console.Write("{0}[{1},{2}] = ", name, i, j);
                    matrix[i, j] = rand.Next(10);
                }
            }

            return matrix;
        }

        public static void PrintMatrixMultiplication(int[,] matrixA, int[,] matrixB, int[,] matrixC)
        {
            PrintMatrix(matrixA);
            Console.WriteLine("*");
            PrintMatrix(matrixB);
            Console.WriteLine("=");
            PrintMatrix(matrixC);
        }
        
        private static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.RowsCount(); i++)
            {
                for (var j = 0; j < matrix.ColumnsCount(); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }
    }
}
