namespace _04.FindEvensOdds
{
    using System;
    using System.Linq;

    public class FindEvensOdds
    {
        public static void Main()
        {
            var range = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Predicate<int> separateNums = GetCondition();

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (separateNums(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
        static Predicate<int> GetCondition()
        {
            var keyword = Console.ReadLine();
            if (keyword == "even")
            {
                return x => x % 2 == 0;
            }
            return x => x % 2 != 0;
        }
    }
}
