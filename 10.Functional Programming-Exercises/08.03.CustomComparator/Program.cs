namespace _08._03.CustomComparator
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int, int> compare = PutEvenFirst;

            Array.Sort(nums, (x, y) => compare(x, y));
            Console.WriteLine(String.Join(" ", nums));
        }
        static int PutEvenFirst(int x, int y)
        {
            if (Math.Abs(x % 2) == Math.Abs(y % 2))
            {
                if (x == y)
                {
                    return 0;
                }
                else if (x < y)
                {
                    return -1;
                }
                return 1;
            }
            else
            {
                if (Math.Abs(x % 2) == 0)
                {
                    return -1;
                }
                return 1;
            }
        }
    }
}
