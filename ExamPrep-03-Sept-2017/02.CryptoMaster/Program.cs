using System;
using System.Linq;

namespace _02.CryptoMaster
{
    class Program
    {
        static void Main()
        {
            var numbers = Console
                .ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var best = 0;

            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    var currentIndex = index;
                    var nextIndex = (index + step) % numbers.Length;
                    var currentBest = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentBest++;
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                    }

                    if (currentBest > best)
                    {
                        best = currentBest;
                    }
                }
            }
            Console.WriteLine(best);
        }
    }
}
