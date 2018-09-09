namespace _03._02.GroupNumbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sequence = Console.ReadLine()
               .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[][] jaggedArr = new int[3][];
            jaggedArr[0] = sequence.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            jaggedArr[1] = sequence.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            jaggedArr[2] = sequence.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            foreach (var arr in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
