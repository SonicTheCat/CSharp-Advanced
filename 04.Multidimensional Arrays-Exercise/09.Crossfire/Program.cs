namespace _09.Crossfire
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var matrix = new int[sizes[0]][];

            for (int r = 0; r < matrix.Length; r++)
            {
                var line = new int[sizes[1]];
                for (int c = 0; c < sizes[1]; c++)
                {
                    if (r == 0)
                    {
                        line[c] = c + 1;
                    }
                    else
                    {
                        line[c] = r * sizes[1] + c + 1;
                    }
                }
                matrix[r] = line;
            }

            var command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                var splitCommand = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                matrix = DestroyingCells(matrix, splitCommand);

                command = Console.ReadLine();
            }

            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
        static int[][] DestroyingCells(int[][] matrix, long[] commands)
        {
            long nukeRow = commands[0];
            long nukeCol = commands[1];
            long radius = commands[2];

            for (long row = Math.Max(0, nukeRow - radius); row <= Math.Min(matrix.Length - 1, nukeRow + radius); row++)
            {
                for (long col = Math.Max(0, nukeCol - radius); col <= Math.Min(matrix[row].Length - 1, nukeCol + radius); col++)
                {
                    if (row == nukeRow || col == nukeCol)
                    {
                        matrix[row][col] = 0;
                    }
                }
                matrix[row] = matrix[row].Where(x => x != 0).ToArray();
            }
            return matrix.Where(arr => arr.Length != 0).ToArray();
        }
    }
}