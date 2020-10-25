using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            Stack<string> input = new Stack<string>(
                Console.ReadLine()
                .Split()
                .ToArray());

            Queue<string> halls = new Queue<string>();

            List<int> reservations = new List<int>();

            while (input.Any())
            {
                string currentElement = input.Pop();
                
                if (int.TryParse(currentElement, out int currentReservation))
                {
                    if (reservations.Sum() + currentReservation <= capacity)
                    {
                        if (halls.Any())
                        {
                            reservations.Add(currentReservation);
                        }
                    }
                    else
                    {
                        if (halls.Any())
                        {
                            Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", reservations)}");

                            reservations.Clear();

                            if (halls.Any())
                            {
                                reservations.Add(currentReservation);
                            }
                        }
                    }
                }
                else
                {
                    halls.Enqueue(currentElement);
                }
            }
        }
    }
}
