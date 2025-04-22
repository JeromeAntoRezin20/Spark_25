using Microsoft.Data.SqlClient;
using Student_Info_System.entity;
using Student_Info_System.exception;
using Student_Info_System.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Info_System.dao
{
    public class SIS_CRUD
    {
            public void AddStudent(Student student)
            {
                using SqlConnection conn = DBConnUtil.GetConnection();
                conn.Open();
                string query = "INSERT INTO Students VALUES (@Id, @FirstName, @LastName, @DOB, @Email, @Phone)";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@Id", student.StudentId);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@DOB", student.DateOfBirth);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Phone", student.PhoneNumber);
                cmd.ExecuteNonQuery();
            }

            public void EnrollStudent(Student student, Course course)
            {
                using SqlConnection conn = DBConnUtil.GetConnection();
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM Enrollments WHERE StudentId = @StudentId AND CourseId = @CourseId";
                using SqlCommand checkCmd = new(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                checkCmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                if ((int)checkCmd.ExecuteScalar() > 0)
                    throw new DuplicateEnrollmentException("Student already enrolled.");

                string query = "INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDate) VALUES (@StudentId, @CourseId, @Date)";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }

            public void AssignTeacherToCourse(Course course, Teacher teacher)
            {
                using SqlConnection conn = DBConnUtil.GetConnection();
                conn.Open();
                string query = "UPDATE Courses SET TeacherId = @TeacherId WHERE CourseId = @CourseId";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@TeacherId", teacher.TeacherId);
                cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                cmd.ExecuteNonQuery();
            }

            public void RecordPayment(Student student, decimal amount, DateTime date)
            {
                if (amount <= 0)
                    throw new PaymentValidationException("Invalid payment amount.");

                using SqlConnection conn = DBConnUtil.GetConnection();
                conn.Open();
                string query = "INSERT INTO Payments (StudentId, Amount, PaymentDate) VALUES (@StudentId, @Amount, @Date)";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.ExecuteNonQuery();
            }

            public List<Student> GetStudentsForCourse(string courseName)
            {
                List<Student> students = new();
                using SqlConnection conn = DBConnUtil.GetConnection();
                conn.Open();
                string query = @"SELECT s.StudentId, s.FirstName, s.LastName, s.DateOfBirth, s.Email, s.PhoneNumber
                             FROM Students s
                             JOIN Enrollments e ON s.StudentId = e.StudentId
                             JOIN Courses c ON e.CourseId = c.CourseId
                             WHERE c.CourseName = @CourseName";
                using SqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@CourseName", courseName);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        DateOfBirth = reader.GetDateTime(3),
                        Email = reader.GetString(4),
                        PhoneNumber = reader.GetString(5)
                    });
                }
                return students;
            }
    }
}
