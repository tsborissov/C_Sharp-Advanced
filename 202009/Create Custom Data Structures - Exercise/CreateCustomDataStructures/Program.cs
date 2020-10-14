using System;

namespace CreateCustomDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);


            stack.ForEach(n => Console.WriteLine(n));



        }
    }
}
