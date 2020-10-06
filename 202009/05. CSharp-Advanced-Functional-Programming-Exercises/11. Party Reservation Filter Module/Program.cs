using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> invitations = Console
                .ReadLine()
                .Split()
                .ToList();

            Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input
                .Split(';')
                .ToArray();

                string command = tokens[0];
                string filterType = tokens[1];
                string filterArg = tokens[2];

                switch (command)
                {
                    case "Add filter":
                        AddFilter(filters, filterType, filterArg);
                        break;

                    case "Remove filter":
                        RemoveFilter(filters, filterType, filterArg);
                        break;
                }
            }

            ApplyFilters(invitations, filters);

            Console.WriteLine(String.Join(' ', invitations));
        }

        static void AddFilter(Dictionary<string, List<string>> filters, string filterType, string filterArg)
        {
            if (!filters.ContainsKey(filterType))
            {
                filters.Add(filterType, new List<string>());
            }

            filters[filterType].Add(filterArg);
        }

        static void RemoveFilter(Dictionary<string, List<string>> filters, string filterType, string filterArg)
        {
            if (filters.ContainsKey(filterType))
            {
                filters[filterType].Remove(filterArg);
            }
        }

        static void ApplyFilters(List<string> invitations, Dictionary<string, List<string>> filters)
        {
            foreach (var filter in filters)
            {
                foreach (var filterArg in filter.Value)
                {
                    Predicate<string> filterPredicate = filter.Key switch
                    {
                        "Starts with" => f => f.StartsWith(filterArg),
                        "Ends with" => f => f.EndsWith(filterArg),
                        "Contains" => f => f.Contains(filterArg),
                        "Length" => f => f.Length == int.Parse(filterArg),
                        _ => null
                    };

                    invitations.RemoveAll(filterPredicate);
                }
            }
        }
    }
}
