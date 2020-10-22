using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>
                (
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()
                );

            Stack<int> bombCasings = new Stack<int>
                (
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()
                );

            Dictionary<string, Bomb> bombPouch = new Dictionary<string, Bomb>
            {
                { "Datura Bombs", new Bomb("Datura Bombs", 40, 0) },
                { "Cherry Bombs", new Bomb("Cherry Bombs", 60, 0) },
                { "Smoke Decoy Bombs", new Bomb("Smoke Decoy Bombs", 120, 0) }
            };

            bool isBombPouchFull = false;

            while (true)
            {
                isBombPouchFull =
                    bombPouch["Datura Bombs"].Count >= 3 &&
                    bombPouch["Cherry Bombs"].Count >= 3 &&
                    bombPouch["Smoke Decoy Bombs"].Count >= 3;

                if (bombEffects.Count == 0 || bombCasings.Count == 0 || isBombPouchFull)
                {
                    break;
                }

                int mixSum = bombEffects.Peek() + bombCasings.Peek();

                if (mixSum == bombPouch["Datura Bombs"].Materials)
                {
                    CreateBomb("Datura Bombs", bombEffects, bombCasings, bombPouch);
                }
                else if (mixSum == bombPouch["Cherry Bombs"].Materials)
                {
                    CreateBomb("Cherry Bombs", bombEffects, bombCasings, bombPouch);
                }
                else if (mixSum == bombPouch["Smoke Decoy Bombs"].Materials)
                {
                    CreateBomb("Smoke Decoy Bombs", bombEffects, bombCasings, bombPouch);
                }
                else
                {
                    int currentBombCasing = bombCasings.Pop();
                    bombCasings.Push(currentBombCasing - 5);
                }
            }

            if (isBombPouchFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }

            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }

            foreach (var bomb in bombPouch.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value.Count}");
            }

        }

        private static void CreateBomb(string bomb, Queue<int> bombEffects, Stack<int> bombCasings, Dictionary<string, Bomb> bombPouch)
        {
            bombPouch[bomb].Count++;

            bombEffects.Dequeue();
            bombCasings.Pop();
        }
    }

    public class Bomb
    {
        public Bomb(string name, int materials, int count)
        {
            this.Name = name;
            this.Materials = materials;
            this.Count = count;
        }

        public string Name { get; set; }
        public int Materials { get; set; }
        public int Count { get; set; }
    }
}
