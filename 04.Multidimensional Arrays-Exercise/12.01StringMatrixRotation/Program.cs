namespace _12.StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        static List<string> storeData = new List<string>();

        public static void Main()
        {
            var input = Regex
                .Split(Console.ReadLine(), @"\D+")
                .Where(x => x != "")
                .ToArray();

            var command = Console.ReadLine();

            while (command != "END")
            {
                storeData.Add(command);

                command = Console.ReadLine();
            }

            var matrix = FillUpMatrix();
            var degrees = int.Parse(input[0]) % 360;

            if (degrees == 90)
            {
                Rotate90Degrees(matrix);
            }
            else if (degrees == 180)
            {
                Rotate180Degrees(matrix);
            }
            else if (degrees == 270)
            {
                Rotate270Degrees(matrix);
            }
            else if (degrees == 0)
            {
                Rotate360Degrees(matrix);
            }
        }
        static char[,] FillUpMatrix()
        {
            int rows = storeData.Count;
            int cols = -1;
            foreach (var word in storeData)
            {
                if (word.Length > cols)
                {
                    cols = word.Length;
                }
            }
            var matrix = new char[rows, cols];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (c < storeData[r].Length)
                    {
                        matrix[r, c] = storeData[r][c];
                        continue;
                    }
                    matrix[r, c] = ' ';
                }
            }
            return matrix;
        }
        static void Rotate90Degrees(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static void Rotate180Degrees(char[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static void Rotate270Degrees(char[,] matrix)
        {
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static void Rotate360Degrees(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
