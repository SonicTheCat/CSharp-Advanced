using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine();

        var pattern = @"\[[A-Z&a-z]+<([0-9]+)REGEH([0-9]+)>[A-Z&a-z]+\]";
        Regex regex = new Regex(pattern);

        MatchCollection matches = regex.Matches(input);
        var textResult = string.Empty;
        var index = 0;

        foreach (Match match in matches)
        {
            for (int i = 1; i < match.Groups.Count; i++)
            {
                var number = int.Parse(match.Groups[i].Value);
                index += number;
                index = index % input.Length;

                textResult += input[index];
            }
        }
        Console.WriteLine(textResult);
    }
}