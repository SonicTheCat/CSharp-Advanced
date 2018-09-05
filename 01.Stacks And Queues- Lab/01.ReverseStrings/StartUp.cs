namespace _01.ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string str = Console.ReadLine(); 

            Stack<string> reverseStr = new Stack<string>();
            foreach (var letter in str)
            {
                reverseStr.Push(letter.ToString()); 
            }
            while (reverseStr.Count > 0)
            {
                Console.Write(reverseStr.Pop());
            }
            Console.WriteLine();
        }
    }
}
