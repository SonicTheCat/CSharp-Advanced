using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MovieTime
{
    class Program
    {
        static void Main()
        {
            var favGenre = Console.ReadLine();
            var preferedDuration = Console.ReadLine();

            var movies = new Dictionary<string, TimeSpan>();
            TimeSpan totalDuration = new TimeSpan();

            string command;
            while ((command = Console.ReadLine()) != "POPCORN!")
            {
                var tokens = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                var title = tokens[0];
                var genre = tokens[1];
                var duration = tokens[2];

                totalDuration = totalDuration.Add(TimeSpan.Parse(duration));
                if (favGenre == genre)
                {
                    movies[title] = TimeSpan.Parse(duration);
                }
            }

            movies = movies
                .OrderBy(x => preferedDuration == "Short" ? x.Value.Duration() : -x.Value.Duration())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Key);

                var answer = Console.ReadLine();
                if (answer.ToLower() == "yes")
                {
                    Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                    Console.WriteLine($"Total Playlist Duration: {totalDuration}");
                    break;
                }
            }
        }
    }
}