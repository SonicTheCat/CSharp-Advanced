using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                for (int j = 0; j < input.Length; j++)
                {
                    set.Add(input[j]);
                }
            }
            foreach (var item in set.OrderBy(x => x))
            {
                Console.Write(item + " ");
            }
        }
    }
}
