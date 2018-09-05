namespace _02.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Reverse();
            var calculator = new Stack<string>(input);

            while (calculator.Count > 1)
            {
                int num1 = int.Parse(calculator.Pop());
                string operand = calculator.Pop();
                int num2 = int.Parse(calculator.Pop());

                switch (operand)
                {
                    case "+": calculator.Push((num1 + num2).ToString()); break;
                    case "-": calculator.Push((num1 - num2).ToString()); break;
                }
            }
            Console.WriteLine(calculator.Pop());
        }
    }
}
