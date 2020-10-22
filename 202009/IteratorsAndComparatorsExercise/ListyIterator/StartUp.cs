using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<string> elements = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToList();

            var listyInterator = new ListyIterator<string>(elements);
            
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    if (command == "Move")
                    {
                        Console.WriteLine(listyInterator.Move());
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(listyInterator.HasNext());
                    }
                    else if (command == "Print")
                    {
                        listyInterator.Print();
                    }
                    else if (command == "PrintAll")
                    {
                        Console.WriteLine(string.Join(' ', listyInterator));
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
