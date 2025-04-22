using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Info_System.exception
{
        public class DuplicateEnrollmentException : Exception { public DuplicateEnrollmentException(string msg) : base(msg) { } }
        public class CourseNotFoundException : Exception { public CourseNotFoundException(string msg) : base(msg) { } }
        public class StudentNotFoundException : Exception { public StudentNotFoundException(string msg) : base(msg) { } }
        public class TeacherNotFoundException : Exception { public TeacherNotFoundException(string msg) : base(msg) { } }
        public class PaymentValidationException : Exception { public PaymentValidationException(string msg) : base(msg) { } }

}

