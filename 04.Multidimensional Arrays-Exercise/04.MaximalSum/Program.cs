namespace _04.MaximalSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrix = new int[sizes[0]][];
            FillUpColumns(matrix);

            int sum = int.MinValue;
            int printRow = -1;
            int printCol = -1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (row + 3 <= matrix.Length && col + 3 <= matrix[row].Length)
                    {
                        int currentSum = CalculateCurrentSum(matrix, row, col);

                        if (currentSum > sum)
                        {
                            sum = currentSum;
                            printRow = row;
                            printCol = col;
                        }
                    }
                }
            }
            PrintResult(sum, printRow, printCol, matrix);
        }
        static void FillUpColumns(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var column = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = column;
            }
        }
        static int CalculateCurrentSum(int[][] matrix, int startRow, int startCol)
        {
            int sum = 0;
            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    sum += matrix[row][col];
                }
            }
            return sum;
        }
        static void PrintResult(int sum, int startRow, int startCol, int[][] matrix)
        {
            Console.WriteLine("Sum = " + sum);
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }    
    }
}