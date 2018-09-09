namespace _03.GroupNumbers
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

            string[][] jaggedArr = new string[3][];

            for (int i = 0; i < 3; i++)
            {
                string str = string.Empty;
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (Math.Abs(sequence[j]) % 3 == i)
                    {
                        str += sequence[j] + " ";
                    }
                }
                jaggedArr[i] = str.Split(' ');
            }

            foreach (var arr in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
