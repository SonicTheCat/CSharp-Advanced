using System;

class Program
{
    private static char[][] matrix;
    private static int[][] knightsToRemove;

    static void Main()
    {
        FillUpMatrix();

        var removed = 0;
        while (true)
        {
            FillUpKnightsMatrix();

            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix[r][c] == 'K')
                    {
                        MoveLeftDown(r, c);
                        MoveRightDown(r, c);
                        MoveLeftUp(r, c);
                        MoveRightUp(r, c);
                    }
                }
            }

            if (!RemoveMostAttackedKnight())
            {
                break;
            }

            removed++;
        }
        Console.WriteLine(removed);
    }

    static void MoveRightDown(int row, int col)
    {
        int newRow = row + 2;
        int newCol = col + 1;
        ValidateRightDownMove(newRow, newCol);

        newRow = row + 1;
        newCol = col + 2;
        ValidateRightDownMove(newRow, newCol);
    }
  
    static void MoveLeftDown(int row, int col)
    {
        int newRow = row + 2;
        int newCol = col - 1;
        ValidateLeftDownMove(newRow, newCol);

        newRow = row + 1;
        newCol = col - 2;
        ValidateLeftDownMove(newRow, newCol);
    }

    static void MoveRightUp(int row, int col)
    {
        int newRow = row - 2;
        int newCol = col + 1;
        ValidateRightUpMove(newRow, newCol);

        newRow = row - 1;
        newCol = col + 2;
        ValidateRightUpMove(newRow, newCol);
    }

    static void MoveLeftUp(int row, int col)
    {
        int newRow = row - 2;
        int newCol = col - 1;
        ValidateLeftUpMove(newRow, newCol);

        newRow = row - 1;
        newCol = col - 2;
        ValidateLeftUpMove(newRow, newCol);
    }

    static void ValidateRightDownMove(int row, int col)
    {
        if (col < matrix.Length && row < matrix.Length)
        {
            IsKnight(row, col);
        }
    }

    static void ValidateLeftDownMove(int row, int col)
    {
        if (col >= 0 && row < matrix.Length)
        {
            IsKnight(row, col);
        }
    }

    static void ValidateRightUpMove(int row, int col)
    {
        if (col < matrix.Length && row >= 0)
        {
            IsKnight(row, col);
        }
    }

    static void ValidateLeftUpMove(int row, int col)
    {
        if (col >= 0 && row >= 0)
        {
            IsKnight(row, col);
        }
    }

    static void IsKnight(int row, int col)
    {
        if (matrix[row][col] == 'K')
        {
            knightsToRemove[row][col]++;
        }
    }

    static void FillUpMatrix()
    {
        int n = int.Parse(Console.ReadLine());
        matrix = new char[n][];
        knightsToRemove = new int[n][]; 

        for (int i = 0; i < n; i++)
        {
            matrix[i] = Console.ReadLine().Trim().ToCharArray();
        }
    }

    static void FillUpKnightsMatrix()
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            knightsToRemove[i] = new int[matrix.Length];
        }
    }

    static bool RemoveMostAttackedKnight()
    {
        var mostAttacked = 0;
        int removeRow = 0;
        int removeCol = 0;
        for (int r = 0; r < knightsToRemove.Length; r++)
        {
            for (int c = 0; c < knightsToRemove[r].Length; c++)
            {
                if (knightsToRemove[r][c] > mostAttacked)
                {
                    removeRow = r;
                    removeCol = c;
                    mostAttacked = knightsToRemove[r][c];
                }
            }
        }
        if (mostAttacked == 0)
        {
            return false;
        }
        matrix[removeRow][removeCol] = '0';
        return true;
    }
}