using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split().ToArray();

            var calcStack = new Stack<string>(input.Reverse());

            while (calcStack.Count > 1)
            {
                int operatorA = int.Parse(calcStack.Pop());
                string operand = calcStack.Pop();
                int operatorB = int.Parse(calcStack.Pop());

                switch (operand)
                {
                    case "+":

                        calcStack.Push((operatorA + operatorB).ToString());

                        break;

                    case "-":

                        calcStack.Push((operatorA - operatorB).ToString());

                        break;
                }
            }

            Console.WriteLine(calcStack.Pop());

        }
    }
}
