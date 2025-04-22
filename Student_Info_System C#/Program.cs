using Student_Info_System.entity;
using Microsoft.Data.SqlClient;
using Student_Info_System.exception;
using Student_Info_System.Util;
using Student_Info_System.dao;

public class MainModule
{
    public static void Main(string[] args)
    {
        SIS_CRUD dao = new();

        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Add Student\n2. Add Teacher\n3. Add Course\n4. Enroll Student\n5. Record Payment\n6. Assign Teacher\n7. View Enrolled Students\n8. Exit");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID: ");
                        int sid = int.Parse(Console.ReadLine());
                        Console.Write("First Name: ");
                        string fname = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lname = Console.ReadLine();
                        Console.Write("DOB (yyyy-mm-dd): ");
                        DateTime dob = DateTime.Parse(Console.ReadLine());
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Phone: ");
                        string phone = Console.ReadLine();

                        dao.AddStudent(new Student { StudentId = sid, FirstName = fname, LastName = lname, DateOfBirth = dob, Email = email, PhoneNumber = phone });
                        Console.WriteLine("Student added.");
                        break;

                    case "2":
                        Console.WriteLine("Teacher module ready.");
                        break;

                    case "3":
                        Console.WriteLine("Course module ready.");
                        break;

                    case "4":
                        Console.Write("Enter Student ID: ");
                        int estudentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course ID: ");
                        int ecourseId = int.Parse(Console.ReadLine());
                        dao.EnrollStudent(new Student { StudentId = estudentId }, new Course { CourseId = ecourseId });
                        Console.WriteLine("Student enrolled.");
                        break;

                    case "5":
                        Console.Write("Enter Student ID: ");
                        int pid = int.Parse(Console.ReadLine());
                        Console.Write("Amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        dao.RecordPayment(new Student { StudentId = pid }, amount, DateTime.Now);
                        Console.WriteLine("Payment recorded.");
                        break;

                    case "6":
                        Console.Write("Enter Course ID: ");
                        int cid = int.Parse(Console.ReadLine());
                        Console.Write("Enter Teacher ID: ");
                        int tid = int.Parse(Console.ReadLine());
                        dao.AssignTeacherToCourse(new Course { CourseId = cid }, new Teacher { TeacherId = tid });
                        Console.WriteLine("Teacher assigned.");
                        break;

                    case "7":
                        Console.Write("Enter Course Name: ");
                        string cname = Console.ReadLine();
                        foreach (var s in dao.GetStudentsForCourse(cname))
                            Console.WriteLine($"{s.FirstName} {s.LastName}");
                        break;

                    case "8":
                        Console.WriteLine("Goodbye!"); return;

                    default:
                        Console.WriteLine("Invalid."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

