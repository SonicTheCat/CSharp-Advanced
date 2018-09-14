namespace _05.RubiksMatrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = FillUpMatrix(sizes);

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var direction = commands[1];
                var moves = int.Parse(commands[2]);

                if (direction == "up" || direction == "down")
                {
                    int column = int.Parse(commands[0]);

                    if (direction == "up")
                    {
                        RotateUp(matrix, column, moves);
                    }
                    else
                    {
                        RotateDown(matrix, column, moves);
                    }
                }
                else
                {
                    int row = int.Parse(commands[0]);

                    if (direction == "left")
                    {
                        RotateToLeft(matrix[row], moves);

                    }
                    else
                    {
                        RotateToRight(matrix[row], moves);
                    }
                }
            }
            RearrangeAndPrint(matrix);
        }
        static void RearrangeAndPrint(int[][] matrix)
        {
            int counter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        var indexes = FindNumberAtCurrentIndex(matrix, counter)
                              .Split(' ')
                              .Select(int.Parse)
                              .ToArray();

                        int biggerNumber = matrix[row][col];
                        matrix[row][col] = counter;
                        matrix[indexes[0]][indexes[1]] = biggerNumber;

                        Console.WriteLine($"Swap ({row}, {col}) with ({indexes[0]}, {indexes[1]})");
                    }
                    counter++;
                }
            }
        }
        static string FindNumberAtCurrentIndex(int[][] matrix, int number)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == number)
                    {
                        return row + " " + col;
                    }
                }
            }
            return " ";
        }
        static void RotateDown(int[][] matrix, int col, int moves)
        {
            moves = moves % matrix.Length;

            for (int i = 0; i < moves; i++)
            {
                int last = matrix[matrix.Length - 1][col];
                for (int j = matrix.Length - 1; j >= 1; j--)
                {
                    matrix[j][col] = matrix[j - 1][col];
                }
                matrix[0][col] = last;
            }
        }
        static void RotateUp(int[][] matrix, int col, int moves)
        {
            moves = moves % matrix.Length;

            for (int i = 0; i < moves; i++)
            {
                int first = matrix[0][col];
                for (int j = 0; j < matrix.Length - 1; j++)
                {
                    matrix[j][col] = matrix[j + 1][col];
                }
                matrix[matrix.Length - 1][col] = first;
            }
        }
        static void RotateToRight(int[] arr, int moves)
        {
            moves = moves % arr.Length;

            for (int i = 0; i < moves; i++)
            {
                int last = arr[arr.Length - 1];
                for (int j = arr.Length - 1; j >= 1; j--)
                {
                    arr[j] = arr[j - 1];
                }
                arr[0] = last;
            }
        }
        static void RotateToLeft(int[] arr, int moves)
        {
            moves = moves % arr.Length;

            for (int i = 0; i < moves; i++)
            {
                int first = arr[0];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[arr.Length - 1] = first;
            }
        }
        static int[][] FillUpMatrix(int[] sizes)
        {
            int[][] matrix = new int[sizes[0]][];
            int counter = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                var arr = new int[sizes[1]];
                for (int j = 0; j < sizes[1]; j++)
                {
                    arr[j] = counter++;
                }
                matrix[i] = arr;
            }
            return matrix;
        }
    }
}
