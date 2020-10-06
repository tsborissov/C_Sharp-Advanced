using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split()
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] cmdArgs = input
                    .Split()
                    .ToArray();

                string cmdType = cmdArgs[0];
                string[] predicateArgs = cmdArgs.Skip(1).ToArray();

                Predicate<string> predicate = GetPredicate(predicateArgs);

                switch (cmdType)
                {
                    case "Remove":

                        guests.RemoveAll(predicate);

                        break;

                    case "Double":

                        for (int i = 0; i < guests.Count; i++)
                        {
                            string currentGuest = guests[i];

                            if (predicate(currentGuest))
                            {
                                guests.Insert(i + 1, currentGuest);
                                i++;
                            }
                        }

                        break;
                }
                
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(String.Join(", ", guests) + " are going to the party!");
            }

        }

        static Predicate<string> GetPredicate(string[] predicateArgs)
        {
            string prType = predicateArgs[0];
            string prArg = predicateArgs[1];

            Predicate<string> predicate = prType switch
            {
                "StartsWith" => new Predicate<string>((name) => name.StartsWith(prArg)),
                "EndsWith" => new Predicate<string>((name) => name.EndsWith(prArg)),
                "Length" => new Predicate<string>((name) => name.Length == int.Parse(prArg)),
                _ => null
            };

            return predicate;
        }
    }
}
