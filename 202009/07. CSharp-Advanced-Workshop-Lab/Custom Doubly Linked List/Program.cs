using System;
using System.Linq;

namespace Custom_Doubly_Linked_List
{
    public class Program
    {
        static void Main(string[] args)
        {

            var myList = new DoublyLinkedList();

            myList.AddFirst(6666);
            myList.AddFirst(5555);
            myList.AddFirst(4444);
            myList.AddFirst(3333);
            myList.AddFirst(2222);
            myList.AddFirst(1111);

            int[] arr = myList.ToArray();

            Console.WriteLine(arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
