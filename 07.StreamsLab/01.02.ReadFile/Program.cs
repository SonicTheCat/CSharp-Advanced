namespace _01._02.ReadFile
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            using (var reader = new StreamReader("../../Program.cs"))
            {
                var rowNumber = 1;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("Line" + rowNumber++ + ": " + line);
                }
            }
        }
    }
}
