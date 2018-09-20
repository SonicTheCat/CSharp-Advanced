namespace _05.AppliedArithmetics
{
    using System;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int> manipulateNums = x => x * 2;
            Action<int[]> print = arr => Console.WriteLine(string.Join(" ", arr));

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "print")
                {
                    print(numbers);
                    continue;
                }

                switch (input)
                {
                    case "add": manipulateNums = x => x + 1; break;
                    case "subtract": manipulateNums = x => x - 1; break;
                    case "multiply": manipulateNums = x => x * 2; break;
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = manipulateNums(numbers[i]);
                }
            }
        }
    }
}
