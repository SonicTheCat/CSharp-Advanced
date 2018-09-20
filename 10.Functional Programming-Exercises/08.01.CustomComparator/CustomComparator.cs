namespace _08.CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Predicate<int> isEven = n => n % 2 == 0;

            var evenNums = nums.Where(x => isEven(x)).ToArray();
            var oddNums = nums.Where(x => !isEven(x)).ToArray();

            Array.Sort(evenNums, oddNums); 
            Console.WriteLine(string.Join(" ", evenNums.Concat(oddNums)));
        }
    }
}
