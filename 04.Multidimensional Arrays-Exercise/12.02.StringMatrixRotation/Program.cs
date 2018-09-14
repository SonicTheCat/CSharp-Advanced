namespace _12._02.StringMatrixRotation
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

            var degrees = int.Parse(input[0]) % 360;
            FindOutSizes(degrees);
        }
        static void FindOutSizes(int degrees)
        {
            int rows = -1;
            int cols = storeData.Count;
            foreach (var word in storeData)
            {
                if (word.Length > rows)
                {
                    rows = word.Length;
                }
            }

            if (degrees == 90)
            {
                Rotate90Degrees(new char[rows, cols]);
            }
            else if (degrees == 180)
            {
                Rotate180Degrees(new char[cols, rows]);
            }
            else if (degrees == 270)
            {
                Rotate270Degrees(new char[rows, cols]);
            }
            else if (degrees == 0)
            {
                Rotate360Degrees(new char[cols, rows]);
            }
        }
        static void Rotate90Degrees(char[,] matrix)
        {
            for (int col = matrix.GetLength(1) - 1, i = 0; col >= 0; col--)
            {
                string current = storeData[i++];

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (row < current.Length)
                    {
                        matrix[row, col] = current[row];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
            PrintResutl(matrix);
        }
        static void Rotate180Degrees(char[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1, i = 0; row >= 0; row--)
            {
                string current = storeData[i++];
                int index = current.Length - 1;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix.GetLength(1) - col > current.Length)
                    {
                        matrix[row, col] = ' ';
                    }
                    else
                    {
                        matrix[row, col] = current[index--];
                    }
                }
            }
            PrintResutl(matrix);
        }
        static void Rotate270Degrees(char[,] matrix)
        {
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                string current = storeData[col];
                int index = current.Length - 1;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (current.Length < matrix.GetLength(0) - row)
                    {
                        matrix[row, col] = ' ';
                    }
                    else
                    {
                        matrix[row, col] = current[index--];
                    }
                }
            }
            PrintResutl(matrix);
        }
        static void Rotate360Degrees(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string current = storeData[row];
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (current.Length > col)
                    {
                        matrix[row, col] = current[col];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
            PrintResutl(matrix);
        }
        static void PrintResutl(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }
    }
}
