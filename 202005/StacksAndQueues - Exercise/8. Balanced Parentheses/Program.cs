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

            if (parenthesesSequence.Length % 2 == 0)
            {
                for (int i = 0; i < parenthesesSequence.Length; i++)
                {
                    if (parenthesesSequence[i] == '(' || parenthesesSequence[i] == '{' || parenthesesSequence[i] == '[')
                    {
                        openingParantheses.Push(parenthesesSequence[i]);
                    }
                    else
                    {
                        switch (parenthesesSequence[i])
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

                        }
                    }

                    if (!isCurlyParanthBallanced || !isRoundParanthBallanced || !isSquareParanthBallanced)
                    {
                        result = "NO";
                        break;
                    }
                }
            }
            else
            {
                result = "NO";
            }
            

            Console.WriteLine(result);

        }
    }
}
