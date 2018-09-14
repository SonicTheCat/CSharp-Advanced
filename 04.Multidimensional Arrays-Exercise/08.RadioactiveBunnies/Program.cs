namespace _08.RadioactiveBunnies
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            var matrix = new char[rows][];

            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine().ToCharArray();
                matrix[r] = line;
            }

            var directions = Console.ReadLine();
            var player = new int[2] { -1, -1 };

            foreach (var move in directions)
            {
                if (player[0] == -1)
                {
                    FindPlayerPosition(matrix, player);
                }
                MovePlayer(matrix, move, player);
            }
        }
        static void GameOver(char[][] matrix, int[] player, string keyWord)
        {
            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join("", arr));
            }
            Console.WriteLine($"{keyWord}: {player[0]} {player[1]}");
            Environment.Exit(0);
        }
        static char[][] CloningMatrix(char[][] matrix)
        {
            var clonedMatrix = new char[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                var cloning = new char[matrix[i].Length];
                matrix[i].CopyTo(cloning, 0);
                clonedMatrix[i] = cloning;
            }
            return clonedMatrix;
        }
        static void BunniesInProduction(char[][] matrix, int row, int col)
        {
            if (row + 1 < matrix.Length)
            {
                matrix[row + 1][col] = 'B';
            }
            if (row - 1 >= 0)
            {
                matrix[row - 1][col] = 'B';
            }
            if (col - 1 >= 0)
            {
                matrix[row][col - 1] = 'B';
            }
            if (col + 1 < matrix[row].Length)
            {
                matrix[row][col + 1] = 'B';
            }
        }
        static void FindBunnies(char[][] matrix)
        {
            var clonedMatrix = CloningMatrix(matrix);

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        BunniesInProduction(clonedMatrix, row, col);
                    }
                }
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = clonedMatrix[i];
            }
        }
        static void ValidateNextMove(char[][] matrix, int row, int col, int[] player)
        {
            if (matrix[row][col] == '.')
            {
                matrix[row][col] = 'P';
            }
            player[0] = row;
            player[1] = col;

            FindBunnies(matrix);
            if (matrix[row][col] == 'B')
            {
                GameOver(matrix, player, "dead");
            }
        }
        static void MovePlayer(char[][] matrix, char move, int[] player)
        {
            int playaRow = player[0];
            int playaCol = player[1];
            matrix[playaRow][playaCol] = '.';

            if (move == 'U' && playaRow - 1 >= 0)
            {
                ValidateNextMove(matrix, playaRow - 1, playaCol, player);
            }
            else if (move == 'D' && playaRow + 1 < matrix.Length)
            {
                ValidateNextMove(matrix, playaRow + 1, playaCol, player);
            }
            else if (move == 'R' && playaCol + 1 < matrix[playaRow].Length)
            {
                ValidateNextMove(matrix, playaRow, playaCol + 1, player);
            }
            else if (move == 'L' && playaCol - 1 >= 0)
            {
                ValidateNextMove(matrix, playaRow, playaCol - 1, player);
            }
            else
            {
                FindBunnies(matrix);
                GameOver(matrix, player, "won");
            }
        }
        static void FindPlayerPosition(char[][] matrix, int[] player)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix[r][c] == 'P')
                    {
                        player[0] = r;
                        player[1] = c;
                    }
                }
            }
        }
    }
}
