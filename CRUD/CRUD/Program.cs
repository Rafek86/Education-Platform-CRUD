using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CRUD
{
    internal class Program
    {
        //Rafeknaim@gmail.com for admin Mode
        static void Main(string[] args)
        {
            List<string> CoursesLevel1 = new List<string>()
            {
                "Introduction to Programming",
                "Algorithm",
                "Data Structure",
                "Information Security",
                "Network"
            };

            List<string> CoursesLevel2 = new List<string>()
            {
                "Object Oriented Programming",
                "Discrete Mathematics",
                "Computer Architecture",
                "Operating Systems",
                "Database Systems"
            };

            List<string> CoursesLevel3 = new List<string>()
            {
                "Software Engineering",
                "Human-Computer Interaction",
                "Networks",
                "Information Security",
                "Web Development"
            };

            List<string> CoursesLevel4 = new List<string>()
            {
                "Introduction to Databases",
                "Object-Oriented Programming",
                "Data Structures and Algorithms",
                "Web Development",
                "Computer Networks"
            };

            List<string> CIDs = new List<string>()
            {
                "IT11",
                "IT12",
                "IT21",
                "IT22",
                "IT23"
            };

            List<Student> students = new List<Student>()
            {
                new Student(id: "ST01", name: "Malek", email: "malek-01@gmail.com", pass: "12345", phone: "01011111111",  CName: CoursesLevel1),
                new Student(id: "ST02", name: "Tawfek", email: "Tawfek-02@gmail.com", pass: "12345", phone: "01022222222",  CName: CoursesLevel2),
                new Student(id: "ST03", name: "Medhat", email: "Medhat-03@gmail.com", pass: "12345", phone: "01033333333", CName: CoursesLevel3),
                new Student(id: "ST04", name: "Amr", email: "Amr-04@gmail.com", pass: "12345", phone: "01044444444", CName: CoursesLevel4),
            };

            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(id: "TE01", name: "Yaser", email: "Yaser-01@gmail.com", pass: "12345", phone: "01045678911", classes: "IT01", course: "Introduction to Programming"),
                new Teacher(id: "TE02", name: "Nader", email: "Nader-02@gmail.com", pass: "12345", phone: "01055555555", classes: "IT02", course: "Algorithm"),
                new Teacher(id: "TE03", name: "Walaa", email: "Walaa-03@gmail.com", pass: "12345", phone: "01066666666", classes: "IT03", course: "Data Structure"),
                new Teacher(id: "TE04", name: "Hamada", email: "Hamada-04@gmail.com", pass: "12345", phone: "01077777777", classes: "IT04", course: "Network")
            };

            int x = 0;
            do
            {
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Teacher");
                Console.WriteLine("3. Admin");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=======================");
                Console.Write("Choose a number: ");

                if (int.TryParse(Console.ReadLine(), out x) && x > 0 && x <= 4)
                {
                    if (x == 4) break;

                    if (x == 1)
                    {
                        Student.HandleStudent(students);
                    }
                    else if (x == 2)
                    {
                        Teacher.HandleTeacher(teachers);
                    }
                    else if (x == 3)
                    {
                        Admin.HandleAdmin(students, teachers, CoursesLevel1, CoursesLevel2, CoursesLevel3, CoursesLevel4);
                    }
                    else
                    {
                        Console.WriteLine("Option not implemented yet.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            } while (x != 4);
        }
    }
}
