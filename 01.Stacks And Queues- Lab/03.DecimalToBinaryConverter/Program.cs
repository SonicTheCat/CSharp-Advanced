namespace _03.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            if (num == 0)
            {
                Console.WriteLine(0);
                return;
            }
            var binaryNum = new Stack<int>();

            while (num > 0)
            {
                binaryNum.Push(num % 2);
                num = num / 2;
            }
            foreach (var n in binaryNum)
            {
                Console.Write(n);
            }
            Console.WriteLine();
        }
    }
}
