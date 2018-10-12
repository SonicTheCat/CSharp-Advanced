namespace _01.ArrangeNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console
                .ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var pairs = new Dictionary<char, string>
            {
                { '0' , "zero"},{ '1' , "one"},{ '2' , "two"},{ '3' , "three"},{'4' , "four"}, { '5', "five"},{ '6', "six"},{'7' , "seven"}, { '8' , "eight"},{ '9' , "nine"}
            };

            var sortedNumbers = new Dictionary<string, string>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var number = numbers[i];

                var symbols = new string[number.Length];
                for (int j = 0; j < number.Length; j++)
                {
                    symbols[j] = pairs[number[j]];
                }
                var word = string.Join("-", symbols);

                if (sortedNumbers.ContainsKey(word))
                {
                    sortedNumbers[word] += $", {number}";
                    continue;
                }
                sortedNumbers.Add(word, number);
            }

            Console.WriteLine(string.Join(", ", sortedNumbers
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value)
                .Values
                .ToArray()));
        }
    }
}