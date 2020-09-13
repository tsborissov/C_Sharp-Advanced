using System;
using System.Collections.Generic;

namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {

            string parenthesesSequence = Console.ReadLine();

            Stack<char> openingParantheses = new Stack<char>();

            string result = "YES";

            bool isRoundParanthBallanced = true;
            bool isSquareParanthBallanced = true;
            bool isCurlyParanthBallanced = true;


            for (int i = 0; i < parenthesesSequence.Length / 2; i++)
            {
                openingParantheses.Push(parenthesesSequence[i]);
            }


            for (int j = parenthesesSequence.Length / 2; j < parenthesesSequence.Length; j++)
            {

                switch (parenthesesSequence[j])
                {
                    case ')':

                        if (openingParantheses.Pop() != '(')
                        {
                            isRoundParanthBallanced = false;
                        }

                        break;

                    case ']':

                        if (openingParantheses.Pop() != '[')
                        {
                            isSquareParanthBallanced = false;
                        }

                        break;

                    case '}':

                        if (openingParantheses.Pop() != '{')
                        {
                            isCurlyParanthBallanced = false;
                        }

                        break;

                    default:

                        result = "NO";

                        break;
                }

                if (!isCurlyParanthBallanced || !isRoundParanthBallanced || !isSquareParanthBallanced)
                {
                    result = "NO";
                    break;
                }
            }

            Console.WriteLine(result);

        }
    }
}
