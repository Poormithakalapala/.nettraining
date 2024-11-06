using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string Semester { get; set; }
        public string Branch { get; set; }
        public int[] Marks { get; set; } = new int[5];


        public Student(int rollNo, string name, string className, string semester, string branch)
        {
            RollNo = rollNo;
            Name = name;
            ClassName = className;
            Semester = semester;
            Branch = branch;
        }


        public void GetMarks()
        {
            Console.WriteLine("Enter marks for 5 subjects:");

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter marks for subject {i + 1}: ");
                Marks[i] = int.Parse(Console.ReadLine());
            }
        }


        public void DisplayResult()
        {
            int totalMarks = 0;
            bool failedSubject = false;


            foreach (int mark in Marks)
            {
                totalMarks += mark;
                if (mark < 35)
                {
                    failedSubject = true;
                    break;
                }
            }


            if (failedSubject)
            {
                Console.WriteLine("Result: Failed (one or more subjects have marks less than 35)");
                return;
            }


            double average = totalMarks / 5.0;


            if (average < 50)
            {
                Console.WriteLine("Result: Failed (average marks are less than 50)");
            }
            else
            {
                Console.WriteLine("Result: Passed");
            }
        }


        public void DisplayStudentDetails()
        {
            Console.WriteLine($"Roll Number: {RollNo}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {ClassName}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Branch: {Branch}");
        }
    }

    class Marks
    {
        static void Main(string[] args)
        {
            Console.Write("Enter student roll number: ");
            int rollNo = int.Parse(Console.ReadLine());
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student class: ");
            string className = Console.ReadLine();
            Console.Write("Enter student semester: ");
            string semester = Console.ReadLine();
            Console.Write("Enter student branch: ");
            string branch = Console.ReadLine();

            Student student = new Student(rollNo, name, className, semester, branch);
            student.DisplayStudentDetails();
            student.GetMarks();
            student.DisplayResult();
            Console.Read();
        }
    }
}
