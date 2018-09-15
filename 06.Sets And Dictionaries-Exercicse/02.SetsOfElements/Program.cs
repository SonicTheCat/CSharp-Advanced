using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split();
            int n = int.Parse(sizes[0]);
            int m = int.Parse(sizes[1]);

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            for (int i = 1; i <= n + m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i <= n)
                {
                    firstSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }
            }

            firstSet.IntersectWith(secondSet);
            foreach (var item in firstSet)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
