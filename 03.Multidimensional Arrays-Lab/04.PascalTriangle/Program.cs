namespace _04.PascalTriangle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jagged = new long[n][];
            jagged[0] = new long[1] { 1 };

            for (int i = 1; i < n; i++)
            {
                jagged[i] = new long[i + 1];
                jagged[i][0] = 1;
                jagged[i][jagged[i].Length - 1] = 1;
            }
            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (col != 0 && col != jagged[row].Length - 1)
                    {
                        long sum = jagged[row - 1][col - 1] + jagged[row - 1][col];
                        jagged[row][col] = sum;
                    }
                }
            }
            foreach (var arr in jagged)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
