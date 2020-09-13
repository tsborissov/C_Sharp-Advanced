using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Stack<string> undoStack = new Stack<string>();

            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', 2).ToArray();

                string command = tokens[0];

                switch (command)
                {
                    case "1":

                        undoStack.Push(text);

                        string argument = tokens[1];

                        text += argument;

                        break;

                    case "2":

                        undoStack.Push(text);

                        int count = int.Parse(tokens[1]);
                        int startIndex = text.Length - count;

                        text = text.Remove(startIndex, count);

                        break;

                    case "3":

                        int index = int.Parse(tokens[1]) - 1;

                        Console.WriteLine(text.ElementAt(index));

                        break;

                    case "4":

                        if (undoStack.Any())
                        {
                            text = undoStack.Pop();
                        }

                        break;
                }
            }

        }
    }
}
