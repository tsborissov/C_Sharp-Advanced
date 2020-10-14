using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifierClass dateModifier = new DateModifierClass();

            Console.WriteLine(dateModifier.CalculateDaysDifference(startDate, endDate));
        }
    }
}
