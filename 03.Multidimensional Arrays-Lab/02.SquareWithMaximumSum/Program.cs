namespace _02.SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsCols = Console.ReadLine()
               .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[,] matrix = new int[rowsCols[0], rowsCols[1]];
            var sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var values = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                    sum += values[col];
                }
            }

            var biggestSqr = int.MinValue;
            int[,] square = new int[2, 2];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var currentRow = matrix[row, col] + matrix[row, col + 1];
                    var nextRow = matrix[row + 1, col] + matrix[row + 1, col + 1];
                    var currentSqr = currentRow + nextRow;

                    if (currentSqr > biggestSqr)
                    {
                        square[0, 0] = matrix[row, col];
                        square[0, 1] = matrix[row, col + 1];
                        square[1, 0] = matrix[row + 1, col];
                        square[1, 1] = matrix[row + 1, col + 1];
                        biggestSqr = currentSqr;
                    }
                }
            }
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    Console.Write(square[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(biggestSqr);
        }
    }
}
