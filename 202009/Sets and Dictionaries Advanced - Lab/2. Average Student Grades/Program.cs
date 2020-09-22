using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            var studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<decimal>());
                }

                studentGrades[name].Add(grade);
            }

            foreach (var student in studentGrades)
            {
                var grades = new StringBuilder();

                foreach (var grade in student.Value)
                {
                    grades.Append($"{grade:F2} ");
                }
                
                Console.WriteLine($"{student.Key} -> {grades.ToString()}(avg: {student.Value.Average():F2})");
            }
        }
    }
}
