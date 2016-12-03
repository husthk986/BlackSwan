using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_1
{
    class MatrixIncreasingPath
    {
        public void DoIt()
        {
            int[,] matrix = { { 9, 9, 4 }, { 6, 6, 8 }, { 2, 1, 1 } };
            int[,] matrix2 = { { 3, 4, 5 }, { 3, 2, 6 }, { 2, 2, 1 } };
            int[,] matrix3 = { { 3, 4, 5, 0 }, { 3, 2, 6, 0 }, { 2, 2, 1, 0 } };
            int[,] matrix4 = { { 1 } };

            Console.WriteLine("Longest Path of Matrix4 should be 1, actual is: {0}", LongestIncreasingPath(matrix4));

            Console.WriteLine("Longest Path of Matrix3 should be 4, actual is: {0}", LongestIncreasingPath(matrix3));
            Console.WriteLine("Longest Path of Matrix1 should be 4, actual is: {0}", LongestIncreasingPath(matrix));
            Console.WriteLine("Longest Path of Matrix2 should be 4, actual is: {0}", LongestIncreasingPath(matrix2));
        }

        public int LongestIncreasingPath(int[,] matrix)
        {
            if (matrix == null || matrix.Length <= 0)
            {
                return 0;
            }

            int rowDim = matrix.GetLength(0);
            int colDim = matrix.GetLength(1);

            int[,] tempMax = new int[rowDim, colDim];
            for (int i = 0; i < rowDim; i++)
            {
                for (int j = 0; j < colDim; j++)
                {
                    tempMax[i, j] = 0;
                }
            }

            int max = 0;
            for (int i = 0; i < rowDim; i++)
            {
                for (int j = 0; j < colDim; j++)
                {
                    int length = FoundNeighborAround(matrix, tempMax, i, j, rowDim, colDim, int.MaxValue);
                    max = Math.Max(max, length);
                }
            }

            return max;
        }

        private int FoundNeighborAround(int[,] originalMatrix, int[,] neighborMatrix, int rowIndex, int colIndex, int row,
            int col, int pre)
        {
            if (rowIndex < 0 || rowIndex >= row || colIndex >= col || colIndex < 0 || originalMatrix[rowIndex, colIndex] >= pre)
            {
                return 0;
            }

            if (neighborMatrix[rowIndex, colIndex] > 0)
            {
                return neighborMatrix[rowIndex, colIndex];
            }

            int max = 0;
            max = Math.Max(max, FoundNeighborAround(originalMatrix, neighborMatrix, rowIndex, colIndex - 1, row, col, originalMatrix[rowIndex, colIndex])); //left
            max = Math.Max(max, FoundNeighborAround(originalMatrix, neighborMatrix, rowIndex, colIndex + 1, row, col, originalMatrix[rowIndex, colIndex])); //right
            max = Math.Max(max, FoundNeighborAround(originalMatrix, neighborMatrix, rowIndex - 1, colIndex, row, col, originalMatrix[rowIndex, colIndex])); //upper
            max = Math.Max(max, FoundNeighborAround(originalMatrix, neighborMatrix, rowIndex + 1, colIndex, row, col, originalMatrix[rowIndex, colIndex])); //lower

            neighborMatrix[rowIndex, colIndex] = max + 1;

            return max + 1;
        }

        public int LongestIncreasingPath1(int[,] matrix)
        {
            if (matrix == null || matrix.Length <= 0)
            {
                return 0;
            }

            int rowDim = matrix.GetLength(0);
            int colDim = matrix.GetLength(1);

            int[,] tempMax = new int[rowDim, colDim];
            for (int i = 0; i < rowDim; i++)
            {
                for (int j = 0; j < colDim; j++)
                {
                    tempMax[i, j] = 0;
                }
            }

            bool findSomething = true;
            int neighbor = 0;

            while (findSomething)
            {
                findSomething = false;
                for (int i = 0; i < rowDim; i++)
                {
                    for (int j = 0; j < colDim; j++)
                    {
                        if (FoundNeighbor(matrix, tempMax, i, j, rowDim, colDim, neighbor))
                        {
                            tempMax[i, j]++;
                            findSomething = true;
                        }
                    }
                }

                if (findSomething)
                {
                    neighbor++;
                }
            }

            return neighbor + 1;
        }

        private bool FoundNeighbor(int[,] originalMatrix, int[,] neighborMatrix, int rowIndex, int colIndex, int row, int col, int neighborNumber)
        {
            if (colIndex > 0 && originalMatrix[rowIndex, colIndex] < originalMatrix[rowIndex, colIndex - 1] &&
                neighborMatrix[rowIndex, colIndex - 1] >= neighborNumber)
            {
                return true;
            }//Left

            if (rowIndex > 0 && originalMatrix[rowIndex, colIndex] < originalMatrix[rowIndex - 1, colIndex] &&
               neighborMatrix[rowIndex - 1, colIndex] >= neighborNumber)
            {
                return true;
            }//Upper

            if (colIndex < col - 1 && originalMatrix[rowIndex, colIndex] < originalMatrix[rowIndex, colIndex + 1] &&
               neighborMatrix[rowIndex, colIndex + 1] >= neighborNumber)
            {
                return true;
            }//Right

            if (rowIndex < row - 1 && originalMatrix[rowIndex, colIndex] < originalMatrix[rowIndex + 1, colIndex] &&
               neighborMatrix[rowIndex + 1, colIndex] >= neighborNumber)
            {
                return true;
            }//Lower

            return false;
        }

    }
}
