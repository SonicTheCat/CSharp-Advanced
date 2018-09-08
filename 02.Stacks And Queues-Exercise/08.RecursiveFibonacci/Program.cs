namespace _08.RecursiveFibonacci
{
    using System;

    public class Program
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            var arr = new long[51];

            Console.WriteLine(FindFibonaci(n, arr));
        }
        static long FindFibonaci(long n, long[] arr)
        {
            if (arr[n] != 0)
            {
                return arr[n];
            }

            long value = 0;
            if (n == 1)
            {
                value = 1;
            }
            else if (n == 2)
            {
                value = 1;
            }
            else if (n > 2)
            {
                value = FindFibonaci(n - 1, arr) + FindFibonaci(n - 2, arr);
            }

            arr[n] = value;
            return value; 
        }
    }
}
