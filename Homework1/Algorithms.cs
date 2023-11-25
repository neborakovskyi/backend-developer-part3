using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Homework1
{
    public static class Algorithms
    {
        // O(logN)
        public static int BinarySearchByOrderedArray(int[] array, int searchElement)
        {
            var size = array.Length;
            if (size == 0)
            {
                throw new Exception("Array is empty");
            }

            var leftElementIndex = 0;
            var rightElementIndex = array.Length - 1;

            while (leftElementIndex <= rightElementIndex)
            {
                var middleIndex = leftElementIndex + (rightElementIndex - leftElementIndex) / 2;
                if (array[middleIndex] == searchElement)
                {
                    return middleIndex;
                }
                else if (array[middleIndex] < searchElement)
                {
                    leftElementIndex = middleIndex + 1;
                }
                else
                {
                    rightElementIndex = middleIndex - 1;
                }
            }
            return -1;
        }

        // O(n^3)
        public static int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.ColumnsCount() != matrixB.RowsCount())
            {
                throw new Exception("Count columns of matrix A are not equal to count rows of matrix B");
            }

            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }

        // O(n)
        public static int FindMinValue(int[] array)
        {
            var size = array.Length;
            if (size == 0)
            {
                throw new Exception("Array is empty");
            }

            var minValue = int.MaxValue;
            for (var i = 0; i < size - 1; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }
            return minValue;
        }
    }
}
