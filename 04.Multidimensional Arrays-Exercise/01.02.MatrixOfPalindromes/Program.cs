namespace _01._02.MatrixOfPalindromes
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var rowCol = Console.ReadLine().Split(' ');
            int rows = int.Parse(rowCol[0]);
            int cols = int.Parse(rowCol[1]);
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (char)('a' + i) + "" + (char)('a' + i + j) + (char)('a' + i);
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
