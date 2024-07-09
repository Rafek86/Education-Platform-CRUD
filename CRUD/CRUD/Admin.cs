using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRUD
{
    class Admin : User
    {
        public Admin(string id, string name, string email, string pass, string phone)
            : base(id, name, email, pass, phone)
        {
        }




        public static void HandleAdmin(List<Student> students, List<Teacher> teachers, List<string> CoursesLevel1, List<string> CoursesLevel2, List<string> CoursesLevel3, List<string> CoursesLevel4)
        {
            int x = 0;
            Console.Write("Email :");
            string AdminEmail = Console.ReadLine();
            if (AdminEmail == "Rafeknaim@gmail.com")
            {
                do
                {
                    Console.WriteLine("1. Add User");
                    Console.WriteLine("2. Update Data Of User");
                    Console.WriteLine("3. Delete User");
                    Console.WriteLine("4. Print All");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("=======================");
                    Console.Write("Choose a number: ");

                    if (int.TryParse(Console.ReadLine(), out x) && x > 0 && x <= 5)
                    {
                        if (x == 5) break;

                        if (x == 1)
                        {
                            Console.WriteLine("S. Student , T. Teacher");
                            if (char.TryParse(Console.ReadLine(), out char c))
                            {
                                if (char.ToUpper(c) == 'S')
                                {
                                    Console.Write("Choose Level from 1 - 4: ");
                                    if (int.TryParse(Console.ReadLine(), out int y) && y >= 1 && y <= 4)
                                    {
                                        if (y == 1)
                                            Admin.AddStudent(students, CoursesLevel1);
                                        else if (y == 2)
                                            Admin.AddStudent(students, CoursesLevel2);
                                        else if (y == 3)
                                            Admin.AddStudent(students, CoursesLevel3);
                                        else if (y == 4)
                                            Admin.AddStudent(students, CoursesLevel4);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ensure you enter the correct level from 1 - 4");
                                    }
                                }
                                else if (char.ToUpper(c) == 'T')
                                {
                                    Admin.AddTeacher(teachers);
                                }
                                else { Console.WriteLine("Invalid Input"); }
                            }
                        }
                        else if (x == 2)
                        {
                            Console.WriteLine("S. Student , T. Teacher");
                            if (char.TryParse(Console.ReadLine(), out char c))
                            {
                                if (char.ToUpper(c) == 'S')
                                {
                                    Console.Write("Enter ID's Student : ");
                                    string id = Console.ReadLine();
                                    Student student = students.Find(s => s.ID == id);
                                    if (student == null) { Console.WriteLine("The Student is not Exist Currently"); }
                                    else
                                    {
                                        Console.WriteLine("Student Info => ");
                                        Console.WriteLine(student);
                                        int choice;
                                        do
                                        {
                                            Console.WriteLine("1. Edit Email");
                                            Console.WriteLine("2. Edit Name");
                                            Console.WriteLine("3. Edit Phone");
                                            Console.WriteLine("4. Exit");
                                            if (int.TryParse(Console.ReadLine(), out choice))
                                            {
                                                if (choice == 1)
                                                {
                                                    Console.Write("New Email: ");
                                                    string email = Console.ReadLine();
                                                    if (Admin.IsValidEmail(email) && !students.Exists(s => s.Email == email))
                                                    {
                                                        student.Email = email;
                                                        Console.WriteLine("Data updated successfully");
                                                    }
                                                    else { Console.WriteLine("Invalid or duplicate data"); }
                                                }
                                                else if (choice == 2)
                                                {
                                                    Console.Write("New Name: ");
                                                    string name = Console.ReadLine();
                                                    student.Name = name;
                                                    Console.WriteLine("Data updated successfully");
                                                }
                                                else if (choice == 3)
                                                {
                                                    Console.Write("New Phone: ");
                                                    string phone = Console.ReadLine();
                                                    if (Admin.IsValidPhoneNumber(phone) && !students.Exists(s => s.Phone == phone))
                                                    {
                                                        student.Phone = phone;
                                                        Console.WriteLine("Data updated successfully");
                                                    }
                                                    else { Console.WriteLine("Invalid number (must start with {010,011,012,015} and consist of 11 digits) or duplicate data"); }
                                                }
                                            }
                                            else { Console.WriteLine("Invalid input.. try again"); }
                                        }
                                        while (choice != 4);
                                    }
                                }
                                else if (char.ToUpper(c) == 'T')
                                {
                                    Console.Write("Enter ID's Teacher: ");
                                    string id = Console.ReadLine();
                                    Teacher teacher = teachers.Find(t => t.ID == id);
                                    if (teacher == null) { Console.WriteLine("The Teacher is not Exist Currently"); }
                                    else
                                    {
                                        Console.WriteLine("Teacher Info => ");
                                        Console.WriteLine(teacher);
                                        int choice;
                                        do
                                        {
                                            Console.WriteLine("1. Edit Email");
                                            Console.WriteLine("2. Edit Name");
                                            Console.WriteLine("3. Edit Phone");
                                            Console.WriteLine("4. Exit");
                                            if (int.TryParse(Console.ReadLine(), out choice))
                                            {
                                                if (choice == 1)
                                                {
                                                    Console.Write("New Email: ");
                                                    string email = Console.ReadLine();
                                                    if (Admin.IsValidEmail(email) && !teachers.Exists(t => t.Email == email))
                                                    {
                                                        teacher.Email = email;
                                                        Console.WriteLine("Data updated successfully");
                                                    }
                                                    else { Console.WriteLine("Invalid or duplicate data"); }
                                                }
                                                else if (choice == 2)
                                                {
                                                    Console.Write("New Name: ");
                                                    string name = Console.ReadLine();
                                                    teacher.Name = name;
                                                    Console.WriteLine("Data updated successfully");
                                                }
                                                else if (choice == 3)
                                                {
                                                    Console.Write("New Phone: ");
                                                    string phone = Console.ReadLine();
                                                    if (Admin.IsValidPhoneNumber(phone) && !teachers.Exists(t => t.Phone == phone))
                                                    {
                                                        teacher.Phone = phone;
                                                        Console.WriteLine("Data updated successfully");
                                                    }
                                                    else { Console.WriteLine("Invalid input"); }
                                                }
                                            }
                                            else { Console.WriteLine("Invalid input.. try again"); }
                                        }
                                        while (choice != 4);
                                    }
                                }
                                else { Console.WriteLine("Invalid Input"); }
                            }
                        }
                        else if (x == 3)
                        {
                            Console.WriteLine("S. Student , T. Teacher");
                            if (char.TryParse(Console.ReadLine(), out char c))
                            {
                                if (char.ToUpper(c) == 'S')
                                {
                                    Console.Write("Enter ID's Student : ");
                                    string id = Console.ReadLine();
                                    Student student = students.Find(s => s.ID == id);
                                    if (student == null) { Console.WriteLine("The Student is not Exist Currently"); }
                                    else
                                    {
                                        students.Remove(student);
                                        Console.WriteLine("Student removed successfully.");
                                    }
                                }
                                else if (char.ToUpper(c) == 'T')
                                {
                                    Console.Write("Enter ID's Teacher : ");
                                    string id = Console.ReadLine();
                                    Teacher teacher = teachers.Find(t => t.ID == id);
                                    if (teacher == null) { Console.WriteLine("The Teacher is not Exist Currently"); }
                                    else
                                    {
                                        teachers.Remove(teacher);
                                        Console.WriteLine("Teacher removed successfully.");
                                    }
                                }
                                else { Console.WriteLine("Invalid Input"); }
                            }
                        }

                        else if (x == 4)
                        {
                            Console.WriteLine("Students => ");
                            for (int i = 0; i < students.Count; i++) { Console.WriteLine($"{i + 1}. {students[i]}"); }
                            Console.WriteLine("=================");
                            Console.WriteLine("Teachers => ");
                            for (int i = 0; i < teachers.Count; i++) { Console.WriteLine($"{i + 1}. {teachers[i]}"); }
                            Console.WriteLine("=================");
                            Console.WriteLine("Courses Level One => ");
                            for (int i = 0; i < CoursesLevel1.Count; i++) { Console.WriteLine($"{i + 1}. {CoursesLevel1[i]}"); }
                            Console.WriteLine("Courses Level Two => ");
                            for (int i = 0; i < CoursesLevel2.Count; i++) { Console.WriteLine($"{i + 1}. {CoursesLevel2[i]}"); }
                            Console.WriteLine("Courses Level Three => ");
                            for (int i = 0; i < CoursesLevel3.Count; i++) { Console.WriteLine($"{i + 1}. {CoursesLevel3[i]}"); }
                            Console.WriteLine("Courses Level Four => ");
                            for (int i = 0; i < CoursesLevel4.Count; i++) { Console.WriteLine($"{i + 1}. {CoursesLevel4[i]}"); }

                            Console.WriteLine("+++++++++++++++++++++++++++");
                        }
                        else
                        {
                            Console.WriteLine("Option not implemented yet.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    }
                } while (x != 5);
            }
            else { Console.WriteLine("invalid Admin Email"); }
        }





        public static void AddStudent(List<Student> list, List<string> courses)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            Console.Write("ID: ");
            string id = Console.ReadLine();
            if (!IsValidID(id) || list.Exists(s => s.ID == id))
            {
                Console.WriteLine("Invalid ID (Must start with ST+Digits) or duplicate ID.");
                return;
            }

            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            if (!IsValidEmail(email) || list.Exists(s => s.Email == email))
            {
                Console.WriteLine("Invalid or duplicate email.");
                return;
            }

            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            if (!IsValidPhoneNumber(phone) || list.Exists(s => s.Phone == phone))
            {
                Console.WriteLine("Invalid number (Must start with ST+Digits) or duplicate phone number.");
                return;
            }

            Student student = new Student(id, name, email, password, phone, courses);
            student.Courses = new List<string>(courses);

            list.Add(student);
            Console.WriteLine("Student added successfully.");
        }


        public static void AddTeacher(List<Teacher> list)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("ID: ");
            string id = Console.ReadLine();
            if (!IsValidID(id) || list.Exists(t => t.ID == id))
            {
                Console.WriteLine("Invalid ID (Must start with TE+Digits) or duplicate ID.");
                return;
            }

            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            if (!IsValidEmail(email) || list.Exists(t => t.Email == email))
            {
                Console.WriteLine("Invalid or duplicate email");
                return;
            }

            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty");
                return;
            }

            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            if (!IsValidPhoneNumber(phone) || list.Exists(t => t.Phone == phone))
            {
                Console.WriteLine("Invalid number (must start with {010,011,012,015} and consist of 11 digits) or duplicate data");
                return;
            }

            Console.Write("Classes: ");
            string classes = Console.ReadLine();
            if (string.IsNullOrEmpty(classes))
            {
                Console.WriteLine("Classes cannot be empty");
                return;
            }

            Console.Write("Course: ");
            string course = Console.ReadLine();
            if (string.IsNullOrEmpty(course))
            {
                Console.WriteLine("Course cannot be empty");
                return;
            }

            Teacher teacher = new Teacher(id, name, email, password, phone, classes, course);

            list.Add(teacher);
            Console.WriteLine("Teacher added successfully.");
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidID(string id)
        {
            string studentPattern = @"^ST\d+$";
            string teacherPattern = @"^TE\d+$";
            return Regex.IsMatch(id, studentPattern) || Regex.IsMatch(id, teacherPattern);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(012|011|010|015)\d{8}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
