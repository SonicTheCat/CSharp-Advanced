namespace _10.SimpleTextEditoр
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var undo = new Stack<string>();
            var text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');

                switch (input[0])
                {
                    case "1":
                        undo.Push(text);
                        text += input[1];
                        break;
                    case "2":
                        undo.Push(text);
                        int count = int.Parse(input[1]);
                        text = text.Substring(0, text.Length - count);
                        break;
                    case "3":
                        var index = int.Parse(input[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text = undo.Pop();
                        break;
                }
            }
        }
    }
}
