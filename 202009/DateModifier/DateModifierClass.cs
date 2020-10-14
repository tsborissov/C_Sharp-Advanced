using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifierClass
    {
        public int CalculateDaysDifference(string startDateInput, string endDateInput)
        {
            DateTime startDate = DateTime.Parse(startDateInput);
            DateTime endDate = DateTime.Parse(endDateInput);

            return Math.Abs((int)(endDate - startDate).TotalDays);
        }
    }
}
