using System;
using System.Collections.Generic;

namespace _7._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> vipReservations = new HashSet<string>();
            HashSet<string> regularReservations = new HashSet<string>();

            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }

                if (input[0] >= 48 && input[0] <= 57)
                {
                    vipReservations.Add(input);
                }
                else
                {
                    regularReservations.Add(input);
                }

            }

            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input[0] >= 48 && input[0] <= 57)
                {
                    vipReservations.Remove(input);
                }
                else
                {
                    regularReservations.Remove(input);
                }
            }

            Console.WriteLine(vipReservations.Count + regularReservations.Count);

            if (vipReservations.Count > 0)
            {
                foreach (var vip in vipReservations)
                {
                    Console.WriteLine(vip);
                }
            }
            
            if (regularReservations.Count > 0)
            {
                foreach (var reservation in regularReservations)
                {
                    Console.WriteLine(reservation);
                }
            }
        }
    }
}
