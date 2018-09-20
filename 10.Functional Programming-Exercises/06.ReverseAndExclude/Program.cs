namespace _06.ReverseAndExclude
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverse = Reverse;
            Predicate<int> notDivisible = x => x % n != 0;

            Console.WriteLine(string.Join(" ", reverse(nums).Where(x => notDivisible(x))));
        }
        static int[] Reverse(int[] arr)
        {
            var result = new int[arr.Length];
            var counter = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                result[i] = arr[counter++];
            }
            return result;
        }
    }
}