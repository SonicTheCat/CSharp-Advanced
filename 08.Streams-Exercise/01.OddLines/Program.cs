using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main()
        {
            using (var reader = new StreamReader("../../RandomText.txt"))
            {
                var counter = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter++ % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
