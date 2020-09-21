using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor_v3
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Stack<string> undoStack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string tokens = Console.ReadLine();

                string command = tokens.Substring(0, 1);

                string argument = string.Empty;

                switch (command)
                {
                    case "1":

                        undoStack.Push(text.ToString());

                        argument = tokens.Substring(2, tokens.Length - 3);

                        text.Append(argument);

                        break;

                    case "2":

                        undoStack.Push(text.ToString());

                        argument = tokens.Substring(2, tokens.Length - 3);

                        int length = int.Parse(argument);

                        int startIndex = text.Length - length;

                        text.Remove(startIndex, length);

                        break;

                    case "3":

                        argument = tokens.Substring(2, tokens.Length - 3);

                        int elementIndex = int.Parse(argument) - 1;

                        Console.WriteLine(text.ToString().ElementAt(elementIndex));

                        break;

                    case "4":

                        if (undoStack.Count > 0)
                        {
                            text.Clear();
                            text.Append(undoStack.Pop());
                        }

                        break;
                }
            }
        }
    }
}