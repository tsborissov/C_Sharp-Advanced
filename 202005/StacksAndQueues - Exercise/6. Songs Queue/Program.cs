using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray());

            while (songs.Any())
            {
                string[] command = Console.ReadLine().Split(' ', 2).ToArray();

                switch (command[0])
                {
                    case "Play":

                        songs.Dequeue();

                        break;

                    case "Add":

                        string songToAdd = command[1];

                        if (!songs.Contains(songToAdd))
                        {
                            songs.Enqueue(songToAdd);
                        }
                        else
                        {
                            Console.WriteLine($"{songToAdd} is already contained!");
                        }

                        break;

                    case "Show":

                        Console.WriteLine(string.Join(", ", songs));

                        break;
                }
            }

            Console.WriteLine("No more songs!");

        }
    }
}
