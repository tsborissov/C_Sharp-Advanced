using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {

            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int intelligenceValue = int.Parse(Console.ReadLine());

            while (bullets.Any() && locks.Any())
            {
                                
                for (int i = 0; i < gunBarrelSize; i++)
                {
                    if (!bullets.Any() || !locks.Any())
                    {
                        break;
                    }
                    
                    int currentBullet = bullets.Pop();
                    int currentLock = locks.Peek();

                    intelligenceValue -= bulletPrice;

                    if (currentBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }
                }

                if (bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
            }

        }
    }
}
