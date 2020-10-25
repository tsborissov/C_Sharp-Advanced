using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.students = new List<Student>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }
        public int Count { get { return this.students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < this.Capacity)
            {
                this.students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student targetStudent = students.FirstOrDefault(n => n.FirstName == firstName && n.LastName == lastName);

            if (targetStudent != null)
            {
                students.Remove(targetStudent);

                return $"Dismissed student {firstName} {lastName}";
            }


            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            int enrolledStudentsCount = 0;

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in students)
            {
                if (student.Subject == subject)
                {
                    enrolledStudentsCount++;
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }

            if (enrolledStudentsCount > 0)
            {
                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return this.students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.FirstOrDefault(n => n.FirstName == firstName && n.LastName == lastName);
        }
    }
}
