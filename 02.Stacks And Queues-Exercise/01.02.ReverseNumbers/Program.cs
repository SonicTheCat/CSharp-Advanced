using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._02.ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ');
            Stack<string> reverseNums = new Stack<string>();
            for (int i = 0; i < numbers.Length; i++)
            {
                reverseNums.Push(numbers[i]); 
            }
            foreach (var n in reverseNums )
            {
                Console.Write(n + " ");
            }
        }
    }
}
