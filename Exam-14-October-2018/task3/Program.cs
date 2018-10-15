using System;
using System.Linq;

namespace task3
{
    class Program
    {
        private static char[][] matrix;
        private static int[] minerPosition = new int[2];
        private static long allCoalsOnField = 0;
        private static long collectedCols = 0;

        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            matrix = new char[size][];

            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();
            }
            FindMinerPosition();
            FindTotalCoals();

            foreach (var move in command)
            {
                bool inside;
                if (move == "up")
                {
                    inside = IsInsideField(minerPosition[0] - 1, minerPosition[1]);
                    if (inside)
                    {
                        ValidateNewPosition(minerPosition[0] - 1, minerPosition[1]);
                    }

                }
                else if (move == "right")
                {
                    inside = IsInsideField(minerPosition[0], minerPosition[1] + 1);
                    if (inside)
                    {
                        ValidateNewPosition(minerPosition[0], minerPosition[1] + 1);
                    }

                }
                else if (move == "left")
                {
                    inside = IsInsideField(minerPosition[0], minerPosition[1] - 1);
                    if (inside)
                    {
                        ValidateNewPosition(minerPosition[0], minerPosition[1] - 1);
                    }

                }
                else if (move == "down")
                {
                    inside = IsInsideField(minerPosition[0] + 1, minerPosition[1]);
                    if (inside)
                    {
                        ValidateNewPosition(minerPosition[0] + 1, minerPosition[1]);
                    }

                }
            }
            Console.WriteLine
                ($"{allCoalsOnField - collectedCols} coals left. ({minerPosition[0]}, {minerPosition[1]})");
        }
        static void ValidateNewPosition(int newRow, int newCol)
        {
            matrix[minerPosition[0]][minerPosition[1]] = '*';
            if (matrix[newRow][newCol] == 'c')
            {
                collectedCols++;
            }
            else if (matrix[newRow][newCol] == 'e')
            {
                Console.WriteLine($"Game over! ({newRow}, {newCol})");
                Environment.Exit(0);
            }

            minerPosition[0] = newRow;
            minerPosition[1] = newCol;

            if (collectedCols == allCoalsOnField)
            {
                Console.WriteLine($"You collected all coals! ({minerPosition[0]}, {minerPosition[1]})");
                Environment.Exit(0);
            }
        }

        static bool IsInsideField(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix.Length;
        }

        static void FindTotalCoals()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'c')
                    {
                        allCoalsOnField++;
                    }
                }
            }
        }

        static void FindMinerPosition()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 's')
                    {
                        minerPosition[0] = i;
                        minerPosition[1] = j;
                        return;
                    }
                }
            }
        }
    }
}
