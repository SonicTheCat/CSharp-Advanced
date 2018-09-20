namespace _09.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int[], bool> isDivisible = CheckIsDivisible;

            List<int> res = new List<int>();
            for (int i = 1; i <=n; i++)
            {
                if (isDivisible(i, sequence))
                {
                    res.Add(i); 
                }
            }
            Console.WriteLine(string.Join(" ",res));
        }
        static bool CheckIsDivisible(int num, int[] sequence)
        {
            foreach (var seq in sequence)
            {
                if (num % seq != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
