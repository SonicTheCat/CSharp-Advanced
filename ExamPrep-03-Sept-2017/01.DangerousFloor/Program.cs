using System;
using System.Linq;

namespace _01.DangerousFloor
{
    class Program
    {
        private static char[][] board = new char[8][];

        static void Main()
        {
            for (int i = 0; i < board.Length; i++)
            {
                var line = Console
                    .ReadLine()
                    .ToCharArray()
                    .Where(x => x != ',' && x != ' ')
                    .ToArray();

                board[i] = line;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                var figure = tokens[0][0];
                var row = int.Parse(tokens[0][1].ToString());
                var col = int.Parse(tokens[0][2].ToString());

                var targetRow = int.Parse(tokens[1][0].ToString());
                var targetCol = int.Parse(tokens[1][1].ToString());

                if (!DoesFigureExists(figure, row, col))
                {
                    continue;
                }

                var validate = FindFigureToMove(figure);
                bool valid = validate(row, col, targetRow, targetCol);

                if (!valid)
                {
                    PrintInvalidMessage();
                    continue;
                }
                if (!IsInsideBoard(targetRow, targetCol))
                {
                    continue;
                }
                if (board[targetRow][targetCol] != 'x')
                {
                    PrintInvalidMessage();
                    continue;
                }
                MoveFigure(figure, row, col, targetRow, targetCol);
            }
        }
        static Func<int, int, int, int, bool> FindFigureToMove(char figure)
        {
            switch (figure)
            {
                case 'K': return ValidateKingMove;
                case 'R': return ValidateRookMove;
                case 'B': return ValidateBishoMove;
                case 'Q': return ValidateQueenMove;
                default: return ValidatePawnMove;
            }
        }

        static bool ValidateQueenMove(int row, int col, int targetRow, int targetCol)
        {
            if ((row == targetRow || col == targetCol))
            {
                return true; 
            }
            else if(Math.Abs(row - targetRow) == Math.Abs(col - targetCol))
            {
                return true;
            }
            return false; 
        }

        static bool ValidateBishoMove(int row, int col, int targetRow, int targetCol)
        {
            return Math.Abs(row - targetRow) == Math.Abs(col - targetCol);
        }

        static bool ValidateRookMove(int row, int col, int targetRow, int targetCol)
        {
            return row == targetRow || col == targetCol;         
        }

        static bool ValidatePawnMove(int row, int col, int targetRow, int targetCol)
        {
            return row - 1 == targetRow && targetCol == col;          
        }

        static bool ValidateKingMove(int row, int col, int targetRow, int targetCol)
        {
            if ((Math.Abs(row - targetRow) > 1 || Math.Abs(col - targetCol) > 1))
            {           
                return false;
            }
            return true;
        }

        static bool IsInsideBoard(int targetRow, int targetCol)
        {
            if ((targetRow >= board.Length || targetRow < 0) ||
                (targetCol >= board[targetRow].Length || targetCol < 0))
            {
                Console.WriteLine("Move go out of board!");
                return false;
            }
            return true;
        }

        static bool DoesFigureExists(char figure, int row, int col)
        {
            if (board[row][col] != figure)
            {
                Console.WriteLine("There is no such a piece!");
                return false;
            }
            return true;
        }
      
        static void PrintInvalidMessage()
        {
            Console.WriteLine("Invalid move!");
        }

        static void MoveFigure(char figure, int row, int col, int targeRow, int targetCol)
        {
            board[row][col] = 'x';
            board[targeRow][targetCol] = figure;
        }
    }
}