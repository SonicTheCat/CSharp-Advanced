namespace _03.SquaresInMatrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var matrix = new string[input[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                var symbols = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                matrix[i] = symbols;
            }

            int counter = 0;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    string symbol = matrix[row][col];

                    if (symbol == matrix[row][col + 1]
                        && symbol == matrix[row + 1][col]
                        && symbol == matrix[row + 1][col + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
