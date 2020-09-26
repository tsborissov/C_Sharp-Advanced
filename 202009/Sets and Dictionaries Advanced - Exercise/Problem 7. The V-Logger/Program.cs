using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_7._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggerLog = new Dictionary<string, Dictionary<string, HashSet<string>>>(); // vloggername -> followers / following

            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string vloggername = tokens[0];
                string command = tokens[1];

                switch (command)
                {
                    case "joined":

                        if (!vloggerLog.ContainsKey(vloggername))
                        {
                            vloggerLog.Add(vloggername, new Dictionary<string, HashSet<string>>());

                            vloggerLog[vloggername].Add("followers", new HashSet<string>());
                            vloggerLog[vloggername].Add("following", new HashSet<string>());
                        }

                        break;

                    case "followed":

                        string vloggerToFollow = tokens[2];

                        if (vloggername == vloggerToFollow)
                        {
                            continue;
                        }

                        if (!vloggerLog.ContainsKey(vloggername) || !vloggerLog.ContainsKey(vloggerToFollow))
                        {
                            continue;
                        }

                        vloggerLog[vloggername]["following"].Add(vloggerToFollow);
                        vloggerLog[vloggerToFollow]["followers"].Add(vloggername);

                        break;
                }
            }

            var output = new StringBuilder();

            output.Append($"The V-Logger has a total of {vloggerLog.Count} vloggers in its logs.");
            output.Append(Environment.NewLine);

            int row = 1;

            foreach (var vlogger in vloggerLog.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                output.Append($"{row}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                output.Append(Environment.NewLine);

                if (row == 1 && vlogger.Value["followers"].Count > 0)
                {
                    foreach (var follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        output.Append($"*  {follower}");
                        output.Append(Environment.NewLine);
                    }
                }

                row++;
            }

            Console.WriteLine(output.ToString());
        }
    }
}
