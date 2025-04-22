using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Info_System.entity
{
        public class Student
        {
            public int StudentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public List<Enrollment> Enrollments { get; set; } = new();
            public List<Payment> Payments { get; set; } = new();
        }

        public class Course
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }
            public string CourseCode { get; set; }
            public Teacher Instructor { get; set; }
            public List<Enrollment> Enrollments { get; set; } = new();
        }

        public class Enrollment
        {
            public int EnrollmentId { get; set; }
            public Student Student { get; set; }
            public Course Course { get; set; }
            public DateTime EnrollmentDate { get; set; }
        }

        public class Teacher
        {
            public int TeacherId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public List<Course> AssignedCourses { get; set; } = new();
        }

        public class Payment
        {
            public int PaymentId { get; set; }
            public Student Student { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }
}
