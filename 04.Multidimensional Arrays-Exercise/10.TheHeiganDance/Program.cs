namespace _10.TheHeiganDance
{
    using System;
    using System.Linq;

    public class Program
    {
        static int[][] matrix;
        static int playerPoints = 18500;
        static double heiganPoints = 3000000;
        static int playerRow = 7;
        static int playerCol = 7;

        public static void Main()
        {
            matrix = new int[15][];
            var damage = double.Parse(Console.ReadLine());
            var currentDmg = 0;
            var lastSpell = "";

            while (true)
            {
                matrix = matrix.Select(x => x = new int[15]).ToArray();

                var input = Console.ReadLine().Split();
                var spell = input[0];
                var row = int.Parse(input[1]);
                var col = int.Parse(input[2]);

                heiganPoints -= damage;
                playerPoints -= currentDmg;
                currentDmg = 0;

                CheckIfGameOver(lastSpell);

                bool hasToMove = FindSpellArea(row, col);
                if (hasToMove)
                {
                    if (!HasEscaped())
                    {
                        currentDmg = spell == "Cloud" ? 3500 : 6000;
                        playerPoints -= currentDmg;
                        currentDmg = spell == "Cloud" ? 3500 : 0;
                        lastSpell = spell;
                        CheckIfGameOver(spell);
                    }
                }
            }
        }
        static void CheckIfGameOver(string spell)
        {
            if (spell == "Cloud")
                spell = "Plague Cloud";

            if (heiganPoints > 0 && playerPoints > 0)
                return;

            Console
                .WriteLine(heiganPoints <= 0 ? "Heigan: Defeated!" : $"Heigan: {heiganPoints:F2}");
            Console
                .WriteLine(playerPoints <= 0 ? $"Player: Killed by {spell}" : $"Player: {playerPoints}");
            Console
                .WriteLine($"Final position: {playerRow}, {playerCol}");

            Environment.Exit(0);
        }
        static bool FindSpellArea(int row, int col)
        {
            bool move = false;
            for (int r = Math.Max(0, row - 1); r <= Math.Min(row + 1, matrix.Length - 1); r++)
            {
                for (int c = Math.Max(0, col - 1); c <= Math.Min(col + 1, matrix[r].Length - 1); c++)
                {
                    matrix[r][c] = 1;
                    if (r == playerRow && c == playerCol)
                    {
                        move = true;
                    }
                }
            }
            return move;
        }
        static bool HasEscaped()
        {
            if (playerRow - 1 >= 0 && matrix[playerRow - 1][playerCol] != 1)
            {
                playerRow -= 1;
                return true;
            }
            if (playerCol + 1 < matrix[playerRow].Length && matrix[playerRow][playerCol + 1] != 1)
            {
                playerCol += 1;
                return true;
            }
            if (playerRow + 1 < matrix.Length && matrix[playerRow + 1][playerCol] != 1)
            {
                playerRow += 1;
                return true;
            }
            if (playerCol - 1 >= 0 && matrix[playerRow][playerCol - 1] != 1)
            {
                playerCol -= 1;
                return true;
            }
            return false;
        }
    }
}
