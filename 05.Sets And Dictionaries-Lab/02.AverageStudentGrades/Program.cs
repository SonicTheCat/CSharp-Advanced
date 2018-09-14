using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<double>>(); 

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var grade = input[1];

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>()); 
                }
                dict[name].Add(double.Parse(grade));
            }

            foreach (var kvp in dict)
            {
                Console.Write(kvp.Key + " -> ");
                foreach (var grade in kvp.Value)
                {
                    Console.Write($"{grade:F2} ");
                }
                Console.WriteLine($"(avg: {kvp.Value.Average():F2})");
            }
        }
    }
}
