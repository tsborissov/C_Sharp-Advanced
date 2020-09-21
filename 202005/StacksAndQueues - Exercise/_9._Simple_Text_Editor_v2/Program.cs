using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Simple_Text_Editor_v2
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfOperations = int.Parse(Console.ReadLine());

            Stack<string> undoStack = new Stack<string>();

            string text = string.Empty;

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                switch (command[0])
                {
                    case "1":

                        text += command[1];

                        undoStack.Push("1 " + command[1].Length.ToString());

                        break;

                    case "2":

                        int count = int.Parse(command[1]);

                        string substr = text.Substring(text.Length - count);

                        undoStack.Push("2 " + substr);

                        text = text.Remove(text.Length - count);

                        break;

                    case "3":

                        int index = int.Parse(command[1]) - 1;

                        Console.WriteLine(text.ElementAt(index));

                        break;

                    case "4":

                        if (undoStack.Count > 0)
                        {
                            string[] undoCommand = undoStack.Pop().Split();

                            switch (undoCommand[0])
                            {
                                case "1":

                                    int undoCount = int.Parse(undoCommand[1]);

                                    text = text.Remove(text.Length - undoCount);

                                    break;

                                case "2":

                                    string undoText = undoCommand[1];

                                    text += undoText;

                                    break;
                            }

                        }


                        break;
                }
            }

        }
    }
}
