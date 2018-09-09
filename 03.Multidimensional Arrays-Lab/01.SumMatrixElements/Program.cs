namespace _01.SumMatrixElements
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

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
