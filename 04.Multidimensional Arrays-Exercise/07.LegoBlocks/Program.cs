namespace _07.LegoBlocks
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var jaggedOne = new int[n][];
            var jaggedTwo = new int[n][];

            for (int i = 0, j = 0; i < n * 2; i++)
            {
                var line = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (i < n)
                {
                    jaggedOne[i] = line;
                }
                else
                {
                    jaggedTwo[j++] = line;
                }
            }

            foreach (var arr in jaggedTwo)
            {
                Array.Reverse(arr);
            }

            var matrix = new int[n][];
            var length = 0;
            var isMatrix = true;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = jaggedOne[i].Concat(jaggedTwo[i]).ToArray();
                if (i == 0)
                {
                    length = matrix[i].Length;
                }
                else if (matrix[i].Length != length)
                {
                    isMatrix = false;
                }

            }

            if (isMatrix)
            {
                foreach (var arr in matrix)
                {
                    var result = "[" + string.Join(", ", arr) + "]";
                    Console.WriteLine(result);
                }
            }
            else
            {
                int cels = 0;
                foreach (var arr in matrix)
                {
                    cels += arr.Length;
                }
                Console.WriteLine($"The total number of cells is: {cels}");
            }
        }
    }
}
