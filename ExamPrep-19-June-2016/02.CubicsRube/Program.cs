using System;
using System.Linq;

namespace _02.CubicsRube
{
    class Program
    {
        static void Main()
        {
            var sizes = long.Parse(Console.ReadLine());

            var filledCells = 0;
            long sum = 0;
            string input;
            while ((input = Console.ReadLine()) != "Analyze")
            {
                var tokens = input.Split().Select(long.Parse).ToArray();
                var particle = tokens.Last();
                var row = tokens[0];
                var col = tokens[1];
                var third = tokens[2];

                bool inside = IsInside(row, col, third, sizes);
                if (inside && particle != 0)
                {
                    sum += particle;
                    filledCells++;
                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(Math.Pow(sizes, 3) - filledCells);
        }
        static bool IsInside(long row, long col, long third, long sizes)
        {
            return (row >= 0 && row < sizes && col >= 0 && col < sizes && third >= 0 && third < sizes);
        }
    }
}