using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class Student : User
    {

        public List<string> CourseID { get; set; }
        public List<string> Courses { get; set; }


        public Student(string id, string name, string email, string pass, string phone, List<string> CName)
            : base(id, name, email, pass, phone)
        {
            Courses = new List<string>(CName);
        }

        public static void PrintCourses(Student S)
        {
            foreach (string Course in S.Courses)
                Console.WriteLine(Course);
        }

        public static void HandleStudent(List<Student> students)
        {
            Console.Write("Enter Your Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Enter Your Password: ");
            string pass = Console.ReadLine() ?? "";

            Student student = students.Find(s => s.Email == email && s.Password == pass);

            if (student != null)
            {
                Console.WriteLine(student);
                Console.WriteLine("Wanna Show your Courses?");
                Console.WriteLine("Y. Yes ================ N. No");

                if (char.TryParse(Console.ReadLine(), out char y_n))
                {
                    if (char.ToUpper(y_n) == 'Y')
                    {
                        Console.WriteLine("\nYour Courses:");
                        Student.PrintCourses(student);
                        Console.WriteLine("=================");
                    }
                    else if (char.ToUpper(y_n) == 'N')
                    {
                        Console.WriteLine("You chose not to display the courses.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 'Y' or 'N'.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a single character.");
                }
            }
            else
            {
                Console.WriteLine("The Student Info is Not Available.");
            }
        }



        public override string ToString() =>
            $"ID : {this.ID}\nName : {this.Name}\nEmail : {this.Email}\nPhone : {this.Phone}\n";
    }
}
