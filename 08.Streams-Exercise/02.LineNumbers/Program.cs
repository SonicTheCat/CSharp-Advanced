using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main()
        {
            using (var reader = new StreamReader("../../RandomText.txt"))
            {
                using (var writer = new StreamWriter("../../AddLines.txt"))
                {
                    var line = reader.ReadLine();
                    var row = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"Line {row++}:{line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
