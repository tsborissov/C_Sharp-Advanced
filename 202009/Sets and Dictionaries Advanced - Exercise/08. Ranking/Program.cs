using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_8._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {

            var contestsPasswords = new Dictionary<string, string>(); // Contest <-> Password

            string inputContestPasswords = string.Empty;

            while (true)
            {
                inputContestPasswords = Console.ReadLine();
                if (inputContestPasswords == "end of contests")
                {
                    break;
                }

                string[] tokens = inputContestPasswords
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contest = tokens[0];
                string password = tokens[1];

                if (!contestsPasswords.ContainsKey(contest))
                {
                    contestsPasswords.Add(contest, password);
                }
            }

            var submissions = new Dictionary<string, Dictionary<string, int>>(); // user -> contest -> points

            string inputSubmissions = string.Empty;

            while (true)
            {
                inputSubmissions = Console.ReadLine();
                if (inputSubmissions == "end of submissions")
                {
                    break;
                }

                // {contest}=>{password}=>{username}=>{points}

                string[] contestTokens = inputSubmissions
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contest = contestTokens[0];
                string password = contestTokens[1];
                string username = contestTokens[2];
                int points = int.Parse(contestTokens[3]);

                if (!contestsPasswords.ContainsKey(contest))
                {
                    continue;
                }

                if (contestsPasswords[contest] != password)
                {
                    continue;
                }

                if (!submissions.ContainsKey(username))
                {
                    submissions.Add(username, new Dictionary<string, int>());
                }

                if (!submissions[username].ContainsKey(contest))
                {
                    submissions[username].Add(contest, points);
                }
                else
                {
                    if (submissions[username][contest] < points)
                    {
                        submissions[username][contest] = points;
                    }
                }
            }

            int mostPoints = 0;
            string bestUser = string.Empty;

            foreach (var user in submissions)
            {
                int totalPoints = 0;

                foreach (var submission in user.Value)
                {
                    totalPoints += submission.Value;
                }

                if (totalPoints > mostPoints)
                {
                    bestUser = user.Key;
                    mostPoints = totalPoints;
                }
            }

            var output = new StringBuilder();

            output.Append($"Best candidate is {bestUser} with total {mostPoints} points.");
            output.Append(Environment.NewLine);
            output.Append("Ranking:");
            output.Append(Environment.NewLine);

            foreach (var user in submissions.OrderBy(x => x.Key))
            {
                output.Append(user.Key);
                output.Append(Environment.NewLine);

                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    output.Append($"#  {contest.Key} -> {contest.Value}");
                    output.Append(Environment.NewLine);
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
