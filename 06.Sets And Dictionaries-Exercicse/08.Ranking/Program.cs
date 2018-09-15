namespace _08.Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var contestsPasses = new Dictionary<string, string>();
            var input = Console.ReadLine();

            while (input != "end of contests")
            {
                var split = input.Split(':');
                var contest = split[0];
                var password = split[1];

                contestsPasses[contest] = password;
                input = Console.ReadLine();
            }
            var studentsCourses = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var split = input.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                var contest = split[0];
                var password = split[1];
                var student = split[2];
                var points = int.Parse(split[3]);

                if (!contestsPasses.ContainsKey(contest))
                {
                    continue;
                }
                if (contestsPasses[contest] != password)
                {
                    continue;
                }
                if (!studentsCourses.ContainsKey(student))
                {
                    studentsCourses.Add(student, new Dictionary<string, int>());
                }

                if (!studentsCourses[student].ContainsKey(contest))
                {
                    studentsCourses[student][contest] = points;
                }
                else
                {
                    var bestValue = studentsCourses[student][contest];
                    if (bestValue < points)
                    {
                        studentsCourses[student][contest] = points;
                    }
                }
            }

            var bestStudent = studentsCourses
                .OrderByDescending(x => x.Value.Values.Sum())
                .Take(1);
            foreach (var kvp in bestStudent)
            {
                Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value.Values.Sum()} points.");
            }
            Console.WriteLine("Ranking:");
            foreach (var kvp in studentsCourses.OrderBy(x => x.Key))
            {
                var name = kvp.Key;
                var nestedDict = kvp.Value;
                Console.WriteLine(name);

                foreach (var pair in nestedDict.OrderByDescending(x => x.Value))
                {
                    var contest = pair.Key;
                    var points = pair.Value;
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
