using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ');
            Stack<string> reverseNums = new Stack<string>(numbers);
            while (reverseNums.Count != 0)
            {
                Console.Write(reverseNums.Pop() + " ");
            }
        }
    }
}
