using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class Teacher : User
    {
        public string Class { get; set; }
        public string Course { get; set; }



        public Teacher(string id, string name, string email, string pass, string phone, string classes, string course)
            : base(id, name, email, pass, phone)
        {
            Class = classes;
            Course = course;
        }



        public static void HandleTeacher(List<Teacher> teachers)
        {
            Console.Write("Enter Your Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Enter Your Password: ");
            string pass = Console.ReadLine() ?? "";

            Teacher teacher = teachers.Find(t => t.Email == email && t.Password == pass);

            if (teacher != null)
            {
                Console.WriteLine(teacher);
            }
            else
            {
                Console.WriteLine("The Teacher Info is Not Available.");
            }
        }


        public override string ToString()
        {
            return base.ToString() + $"\nClasses : {Class}\nCourse : {Course}";
        }
    }
}
