namespace _02.DiagonalDifference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = arr;
            }

            int firstDiagonal = 0;
            int secondDiagonal = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                firstDiagonal += matrix[row][row];
                secondDiagonal += matrix[row][matrix.Length - 1 - row];
            }
            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));
        }
    }
}
