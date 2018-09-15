using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedDict = new SortedDictionary<char, int>();

            var text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if (!sortedDict.ContainsKey(text[i]))
                {
                    sortedDict.Add(text[i], 0);
                }
                sortedDict[text[i]]++; 
            }

            foreach (var kvp in sortedDict)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value + " time/s");
            }
        }
    }
}
