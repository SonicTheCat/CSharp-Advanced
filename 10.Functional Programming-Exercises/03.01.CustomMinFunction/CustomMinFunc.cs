namespace _03.CustomMinFunction
{
    using System;

    public class CustomMinFunc
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string[], int> findMin = FindSmallest;

            Console.WriteLine(findMin(numbers));
        }

        static int FindSmallest(string[] numbers)
        {
            Func<string, int> convert = n => int.Parse(n);
            int minValue = int.MaxValue;

            foreach (var n in numbers)
            {
                var num = convert(n);
                if (num < minValue)
                {
                    minValue = num;
                }
            }
            return minValue;
        }
    }
}
