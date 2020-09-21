using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<string> undoStack = new Stack<string>();
            string text = string.Empty;

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (input[0])
                {
                    case "1":

                        undoStack.Push(text);

                        text += input[1];

                        break;

                    case "2":

                        undoStack.Push(text);

                        int length = int.Parse(input[1]);

                        text = text.Substring(0, text.Length - length);

                        break;

                    case "3":

                        int index = int.Parse(input[1]) - 1;

                        Console.WriteLine(text[index]);

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
