using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, int, bool> isEqualOrLargerFunc = (text, criteria) => text.Sum(x => x) >=
                criteria;

            Func<string[], int, Func<string, int, bool>, string> findName = (names, totalSum, isLargerName) =>
                names.FirstOrDefault(x => isEqualOrLargerFunc(x, totalSum));

            int targetSum = int.Parse(Console.ReadLine());

            string[] inputNames = Console
                .ReadLine()
                .Split()
                .ToArray();

            string targetName = findName(inputNames, targetSum, isEqualOrLargerFunc);

            Console.WriteLine(targetName);
        }
    }
}
