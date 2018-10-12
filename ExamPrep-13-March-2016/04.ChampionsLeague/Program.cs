using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ChampionsLeague
{
    class Program
    {
        static void Main()
        {
            var teamWins = new Dictionary<string, int>();
            var teamOpponents = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                var tokens = input
                .Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                var firstTeam = tokens[0];
                var secondTeam = tokens[1];

                GetTeamOpponents(teamOpponents, firstTeam, secondTeam);
                GetTeamOpponents(teamOpponents, secondTeam, firstTeam);
                InitializeTeamWins(teamWins, firstTeam);
                InitializeTeamWins(teamWins, secondTeam);

                FindOutWinner(teamWins, tokens);
            }

            foreach (var kvp in teamWins.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                var team = kvp.Key;
                var wins = kvp.Value;
                var opponents = string.Join(", ", teamOpponents[team].OrderBy(x => x).ToArray());
                Console.WriteLine($"{team}\n- Wins: {wins}\n- Opponents: {opponents}");
            }
        }

        static void InitializeTeamWins(Dictionary<string, int> teamWins, string team)
        {
            if (!teamWins.ContainsKey(team))
            {
                teamWins[team] = 0;
            }
        }

        static void GetTeamOpponents(Dictionary<string, List<string>> teamOpponents, string team, string opponent)
        {
            if (!teamOpponents.ContainsKey(team))
            {
                teamOpponents[team] = new List<string>();
            }
            teamOpponents[team].Add(opponent);
        }

        static int FindOutWinner(Dictionary<string, int> teamWins, string[] tokens)
        {
            var firstTeam = tokens[0];
            var secondTeam = tokens[1];

            var gameOne = tokens[2]
                    .Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var gameTwo = tokens[3]
                .Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstTeamGoals = gameOne[0] + gameTwo[1];
            var secondTeamGoals = gameOne[1] + gameTwo[0];

            if (firstTeamGoals == secondTeamGoals)
            {
                return gameOne[1] > gameTwo[1] ? teamWins[secondTeam]++ : teamWins[firstTeam]++;
            }
            return firstTeamGoals > secondTeamGoals ? teamWins[firstTeam]++ : teamWins[secondTeam]++;
        }
    }
}