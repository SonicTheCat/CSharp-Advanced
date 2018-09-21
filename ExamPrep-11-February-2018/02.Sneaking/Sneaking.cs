namespace _02.Sneaking
{
    using System;

    public class Sneaking
    {
        static char[][] matrix;
        static int[] samPosition;
        static int[] nikoladze;

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            matrix = new char[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                var col = Console.ReadLine().Trim().ToCharArray();
                matrix[i] = col;
            }
            var directions = Console.ReadLine();
            FindSamPosition();

            foreach (var direction in directions)
            {
                MoveEnemies();
                isSamAlive();
                MoveSam(direction);
                if (samPosition[0] == nikoladze[0])
                {
                    matrix[nikoladze[0]][nikoladze[1]] = 'X';
                    GameOver("Nikoladze killed!");
                }
            }
        }
        static void MoveSam(char direction)
        {
            matrix[samPosition[0]][samPosition[1]] = '.';
            if (direction == 'U')
            {
                samPosition[0]--;
            }
            else if (direction == 'D')
            {
                samPosition[0]++;
            }
            else if (direction == 'L')
            {
                samPosition[1]--;
            }
            else if (direction == 'R')
            {
                samPosition[1]++;
            }
            matrix[samPosition[0]][samPosition[1]] = 'S';
        }
        static void isSamAlive()
        {
            int samRow = samPosition[0];
            int samCol = samPosition[1];

            for (int c = 0; c < samCol; c++)
            {
                if (matrix[samRow][c] == 'b')
                {
                    matrix[samRow][samCol] = 'X';
                    GameOver($"Sam died at {samPosition[0]}, {samPosition[1]}");
                }
            }
            var cols = matrix[samRow].Length - 1;
            for (int c = cols; c > samCol; c--)
            {
                if (matrix[samRow][c] == 'd')
                {
                    matrix[samRow][samCol] = 'X';
                    GameOver($"Sam died at {samPosition[0]}, {samPosition[1]}");
                }
            }
        }
        static void GameOver(string text)
        {
            Console.WriteLine(text);
            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join("", arr));
            }
            Environment.Exit(0);
        }
        static void FindSamPosition()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        samPosition = new int[] { row, col };
                    }
                    else if (matrix[row][col] == 'N')
                    {
                        nikoladze = new int[] { row, col };
                    }
                }
            }
        }
        static void MoveEnemies()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'd')
                    {
                        MoveDees(row, col);
                    }
                    else if (matrix[row][col] == 'b')
                    {
                        MoveBees(row, col);
                        col++;
                    }
                }
            }
        }
        static void MoveDees(int row, int col)
        {
            if (col > 0)
            {
                matrix[row][col] = '.';
                matrix[row][col - 1] = 'd';
            }
            else
            {
                matrix[row][col] = 'b';
            }
        }
        static void MoveBees(int row, int col)
        {
            if (col < matrix[row].Length - 1)
            {
                matrix[row][col] = '.';
                matrix[row][col + 1] = 'b';
            }
            else
            {
                matrix[row][col] = 'd';
            }
        }
    }
}
