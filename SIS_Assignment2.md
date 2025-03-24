**Task 1. Database Design:**
1. Create the database named "SISDB"

```sql
CREATE DATABASE Student_Info_System;
USE Student_Info_System
```


2. Define the schema for the Students, Courses, Enrollments, Teacher, and Payments tables based on the provided schema. Write SQL scripts to create the mentioned tables with appropriate data types, constraints, and relationships. a. Students b. Courses c. Enrollments d. Teacher e. Payments

```sql

CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    first_name VARCHAR(25),
    last_name VARCHAR(25),
    date_of_birth DATE,
    email VARCHAR(50),
    phone_number CHAR(15)
);


CREATE TABLE Teacher (
    teacher_id INT PRIMARY KEY,
    first_name VARCHAR(25),
    last_name VARCHAR(25),
    email VARCHAR(50)
);

CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    course_name VARCHAR(255),
    credits INT,
    teacher_id INT,
    FOREIGN KEY (teacher_id) REFERENCES Teacher(teacher_id) ON DELETE CASCADE
);

CREATE TABLE Enrollments (
    enrollment_id INT PRIMARY KEY,
    student_id INT,
	FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    course_id INT,
	FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE,
    enrollment_date DATE
);
CREATE TABLE Payments (
    payment_id INT PRIMARY KEY,
    student_id INT,
	FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    amount DECIMAL(10, 2),
    payment_date DATE
);

```
3. Create an ERD (Entity Relationship Diagram) for the database.

![image](https://github.com/user-attachments/assets/d2d73b7b-3860-4941-8494-619d17d2ae21)


5. Insert at least 10 sample records into each of the following tables. i. ii. iii. Students Courses Enrollments iv. Teacher v. Payments

```sql

INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email, phone_number)
VALUES
	(1, 'Rahul', 'Gupta', '2000-03-15', 'rahul.gupta@email.com', '+91-9876543210'),
	(2, 'Priya', 'Sharma', '1999-07-20', 'priya.sharma@email.com', '+91-8765432109'),
	(3, 'Amit', 'Patel', '2001-05-10', 'amit.patel@email.com', '+91-7654321098'),
	(4, 'Sneha', 'Singh', '2002-02-25', 'sneha.singh@email.com', '+91-6543210987'),
	(5, 'Riya', 'Verma', '1998-12-08', 'riya.verma@email.com', '+91-5432109876'),
	(6, 'Kunal', 'Yadav', '2000-11-12', 'kunal.yadav@email.com', '+91-4321098765'),
	(7, 'Swati', 'Das', '1999-09-05', 'swati.das@email.com', '+91-3210987654'),
	(8, 'Raj', 'Kumar', '2001-08-18', 'raj.kumar@email.com', '+91-2109876543'),
	(9, 'Neha', 'Chopra', '1997-06-22', 'neha.chopra@email.com', '+91-1098765432'),
	(10, 'Vikram', 'Saxena', '2002-04-30', 'vikram.saxena@email.com', '+91-9876543210')
 
```

![image](https://github.com/user-attachments/assets/305dc2b7-8570-446c-94a1-859aa45139be)

```sql
INSERT INTO Teacher (teacher_id, first_name, last_name, email)
VALUES
	(1, 'Dr. Anand', 'Sharma', 'anand.sharma@email.com'),
	(2, 'Prof. Deepa', 'Patil', 'deepa.patil@email.com'),
	(3, 'Mrs. Priya', 'Singh', 'priya.singh@email.com'),
	(4, 'Mr. Karthik', 'Rao', 'karthik.rao@email.com'),
	(5, 'Dr. Nisha', 'Verma', 'nisha.verma@email.com'),
	(6, 'Prof. Amit', 'Khanna', 'amit.khanna@email.com'),
	(7, 'Mrs. Shweta', 'Kumar', 'shweta.kumar@email.com'),
	(8, 'Mrs.Anjali', 'Bose', 'anjali.bose@email.com'),
	(9, 'Mr.Aryan', 'Mishra', 'aryan.mishra@email.com'),
(10, 'Mrs.Pooja', 'Gandhi', 'pooja.gandhi@email.com')
 ```

![image](https://github.com/user-attachments/assets/d1b765da-41cb-4eec-b944-af89e98f1283)

```sql
INSERT INTO Courses (course_id, course_name, credits, teacher_id)
VALUES
	(1, 'Advanced Programming Concepts', 4, 7),
	(2, 'Cybersecurity Fundamentals', 4, 1),
	(3, 'Database Management Systems', 2, 7),
	(4, 'Data Visualization Techniques', 2, 6),
	(5, 'Environmental Science Fundamentals', 3, 5),
	(6, 'History of Art and Culture', 3, 4),
	(7, 'Introduction to Computer Science', 3, 2),
	(8, 'Machine Learning Basics', 3, 6),
	(9, 'Mobile App Development Fundamentals', 2, 1),
(10, 'Software Engineering Principles', 3, 1);
```
![image](https://github.com/user-attachments/assets/2005b039-b547-4cbd-860e-0601bececf89)

```sql
INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date)
VALUES
	
	(1, 1, 3, '2025-01-05'),
	(2, 2, 8, '2025-02-10'),
	(3, 3, 4, '2025-03-15'),
	(4, 4, 10, '2025-04-20'),
	(5, 5, 7, '2025-05-25'),
	(6, 6, 1, '2024-06-01'), 
	(7, 7, 2, '2024-07-07'), 
	(8, 8, 5, '2024-08-13'),
	(9, 9, 9, '2024-09-19'),
	(10, 10, 8, '2024-10-25')
```
 ![image](https://github.com/user-attachments/assets/799b82c9-9f7a-4563-a76a-238b277c2bf7)


```sql
INSERT INTO Payments (payment_id, student_id, amount, payment_date)
VALUES
	(1, 1, 500.00, '2025-01-10'),
	(2, 2, 750.50, '2025-02-15'),
	(3, 3, 400.25, '2025-03-20'),
	(4, 4, 600.75, '2025-04-25'),
	(5, 5, 900.00, '2025-05-30'),
	(6, 6, 350.50, '2024-06-05'),
	(7, 7, 800.25, '2024-07-10'),
	(8, 8, 550.75, '2024-08-15'),
	(9, 9, 700.00, '2024-09-20'),
(10, 10, 450.50, '2024-10-25')

```

 ![image](https://github.com/user-attachments/assets/25b11753-7c23-4ae0-b1b1-156fc63e96f7)



Tasks 2: Select, Where, Between, AND, LIKE:

1. Write an SQL query to insert a new student into the "Students" table

```sql
INSERT INTO Students VALUES(11, 'John', 'Doe', '1995-08-15', 'john.doe@example.com', '+91-1234567890');
```
![image](https://github.com/user-attachments/assets/a034af2d-7815-4001-9287-1f3b86984487)

 
2. Write an SQL query to enroll a student in a course. Choose an existing student and course and insert a record into the "Enrollments" table with the enrollment date.

```sql
INSERT INTO Enrollments VALUES(11, 4, 7, '2023-12-2');
```
![image](https://github.com/user-attachments/assets/a26b1541-f417-40f6-bbba-929035fc6d56)


3. Update the email address of a specific teacher in the "Teacher" table. Choose any teacher and modify their email address.
```sql
UPDATE Teacher SET email = 'verma.nisha@hotmail.com' WHERE teacher_id = 5;
```
![image](https://github.com/user-attachments/assets/7d9006bc-1bd8-46c6-8ee7-636aee97812d)

 
4. Write an SQL query to delete a specific enrollment record from the "Enrollments" table. Select an enrollment record based on the student and course.

```sql
DELETE FROM Enrollments WHERE student_id = 4 AND course_id = 10;
```
![image](https://github.com/user-attachments/assets/57a8a801-5de0-4ca5-8ea7-b50e50191fad)

 
5. Update the "Courses" table to assign a specific teacher to a course. Choose any course and teacher from the respective tables.
```sql
UPDATE Courses SET teacher_id = 3 WHERE course_id = 5;
```
![image](https://github.com/user-attachments/assets/b623472d-f585-463f-9297-35dc4388dc8c)

 
6. Delete a specific student from the "Students" table and remove all their enrollment records from the "Enrollments" table. Be sure to maintain referential integrity.
```sql
DELETE FROM Students WHERE student_id = 4;
```
 
![image](https://github.com/user-attachments/assets/ed0ad2da-8bc2-495d-93da-246740ff1136)



7. Update the payment amount for a specific payment record in the "Payments" table. Choose any payment record and modify the payment amount.
```sql
UPDATE Payments SET amount = 675.25 WHERE payment_id = 8;
```

 ![image](https://github.com/user-attachments/assets/e320d861-70ae-4528-8a1d-6f4fb099e93e)




Task 3. Aggregate functions, Having, Order By, GroupBy and Joins:

1. Write an SQL query to calculate the total payments made by a specific student. You will need to join the "Payments" table with the "Students" table based on the student's ID.
```sql

SELECT s.student_id, CONCAT(s.first_name, ' ', s.last_name) as Name, SUM(p.amount) as TotalPayments
FROM Students s JOIN Payments p
ON s.student_id = p.payment_id
GROUP BY s.student_id, s.first_name, s.last_name;
 ```
![image](https://github.com/user-attachments/assets/f1135c5f-70d6-4f49-a7b3-64f5c09cfca5)

2. Write an SQL query to retrieve a list of courses along with the count of students enrolled in each course. Use a JOIN operation between the "Courses" table and the "Enrollments" table.
```sql
SELECT c.course_id, c.course_name, COUNT(e.student_id) as TotalEnrollments
FROM Courses c JOIN Enrollments e
ON c.course_id = e.course_id
GROUP BY c.course_id, c.course_name
```
 ![image](https://github.com/user-attachments/assets/cd3cfcf4-8ac2-47d4-9975-6126941a7177)


3. Write an SQL query to find the names of students who have not enrolled in any course. Use a LEFT JOIN between the "Students" table and the "Enrollments" table to identify students without enrollments.

```sql
SELECT s.student_id, CONCAT(s.first_name, ' ', s.last_name) as Name
FROM Students s LEFT JOIN Enrollments e
ON s.student_id = e.student_id
WHERE e.enrollment_id IS NULL;
```
![image](https://github.com/user-attachments/assets/88ca0c4c-4700-472e-8f37-05634c9e8303)

 

4. Write an SQL query to retrieve the first name, last name of students, and the names of the courses they are enrolled in. Use JOIN operations between the "Students" table and the "Enrollments" and "Courses" tables.

 

5. Create a query to list the names of teachers and the courses they are assigned to. Join the "Teacher" table with the "Courses" table.

```sql
SELECT t.teacher_id, CONCAT(t.first_name, ' ', t.last_name) as Name, c.course_name
FROM Teacher t JOIN Courses c
ON t.teacher_id = c.teacher_id
ORDER BY t.teacher_id;
```
![image](https://github.com/user-attachments/assets/16c4efd8-cac5-47c3-957a-568ae5a0f163)
 


6. Retrieve a list of students and their enrollment dates for a specific course. You'll need to join the "Students" table with the "Enrollments" and "Courses" tables.

```sql
SELECT s.student_id, CONCAT(s.first_name, ' ', s.last_name) as Name, c.course_name, e.enrollment_date
FROM Students s JOIN Enrollments e
ON s.student_id = e.student_id JOIN Courses c
ON e.course_id = c.course_id
ORDER BY s.student_id;
```
 ![image](https://github.com/user-attachments/assets/6e916f19-19b0-4292-95b4-464ab2bf526f)


7. Find the names of students who have not made any payments. Use a LEFT JOIN between the "Students" table and the "Payments" table and filter for students with NULL payment records.

```sql
SELECT s.student_id, CONCAT(s.first_name, ' ', s.last_name) as Name
FROM Students s LEFT JOIN Payments p
ON s.student_id = p.student_id
WHERE p.amount IS NULL;
 ```
![image](https://github.com/user-attachments/assets/d783e9ce-8eed-4195-8ae0-70aea53c5878)


8. Write a query to identify courses that have no enrollments. You'll need to use a LEFT JOIN between the "Courses" table and the "Enrollments" table and filter for courses with NULL enrollment records.

```sql
SELECT c.course_id, c.course_name
FROM Courses c LEFT JOIN Enrollments e
ON c.course_id = e.course_id
WHERE e.enrollment_id IS NULL;
```
 ![image](https://github.com/user-attachments/assets/f6f96f57-93a5-453c-acd8-da775a222a76)



9. Identify students who are enrolled in more than one course. Use a self-join on the "Enrollments" table to find students with multiple enrollment records.

```sql
SELECT DISTINCT e1.student_id
FROM Enrollments e1 JOIN Enrollments e2 
ON e1.student_id = e2.student_id
WHERE e1.course_id <> e2.course_id;
``` 
![image](https://github.com/user-attachments/assets/c3b7415f-479c-4630-ad25-ffd8ae7d2548)


10. Find teachers who are not assigned to any courses. Use a LEFT JOIN between the "Teacher" table and the "Courses" table and filter for teachers with NULL course assignments.
```sql
SELECT t.teacher_id, CONCAT(t.first_name, ' ', t.last_name) as Name
FROM Teacher t LEFT JOIN Courses c
ON t.teacher_id = c.teacher_id
WHERE c.course_id IS NULL;
```
 ![image](https://github.com/user-attachments/assets/d924e1db-be65-4e8d-b75c-6f71a658416d)


Task 4. Subquery and its type:

1. Write an SQL query to calculate the average number of students enrolled in each course. Use aggregate functions and subqueries to achieve this.
```sql
SELECT AVG(te.TotalEnrollments) as Avg_No_Students_Enrolled
FROM (SELECT course_id, COUNT(DISTINCT student_id) AS TotalEnrollments
      FROM Enrollments
      GROUP BY course_id) as te;
 ```
![image](https://github.com/user-attachments/assets/1585d0fb-65a5-4a7c-9591-565d0a472224)


2. Identify the student(s) who made the highest payment. Use a subquery to find the maximum payment amount and then retrieve the student(s) associated with that amount.
```sql
SELECT s.student_id, CONCAT(s.first_name, ' ', s.last_name) as Name
FROM Students s
WHERE s.student_id = (SELECT student_id
		      FROM Payments
		      WHERE amount = (SELECT MAX(amount)
			      	      FROM Payments));
```
![image](https://github.com/user-attachments/assets/36844ff2-9496-46dc-b922-cb14f5008cf3)
 

3. Retrieve a list of courses with the highest number of enrollments. Use subqueries to find the course(s) with the maximum enrollment count.
```sql
SELECT course_id, course_name
FROM Courses
WHERE course_id IN (SELECT TOP 1 WITH TIES e.course_id
		    FROM Enrollments e
		    GROUP BY e.course_id
		    ORDER BY COUNT(e.student_id) DESC);
```
![image](https://github.com/user-attachments/assets/8bf62a4c-5ea1-4182-b42a-d72972a0156b)
 

4. Calculate the total payments made to courses taught by each teacher. Use subqueries to sum payments for each teacher's courses.

```sql
SELECT t.first_name, t.last_name, SUM(p.amount) AS total_payments
FROM Teacher t
JOIN Courses c ON t.teacher_id = c.teacher_id
JOIN Enrollments e ON c.course_id = e.course_id
JOIN Payments p ON e.student_id = p.student_id
GROUP BY t.teacher_id, t.first_name, t.last_name;
```
 ![image](https://github.com/user-attachments/assets/8ed0f841-456a-4fb6-a0ed-8397498734d0)


5. Identify students who are enrolled in all available courses. Use subqueries to compare a student's enrollments with the total number of courses.

```sql
SELECT s.student_id, s.first_name, s.last_name
FROM Enrollments e, Students s
WHERE s.student_id = e.student_id
GROUP BY s.student_id, s.first_name, s.last_name
HAVING COUNT(e.course_id) = (SELECT COUNT(*)
			     FROM Courses);
```

6. Retrieve the names of teachers who have not been assigned to any courses. Use subqueries to find teachers with no course assignments.

```sql
SELECT teacher_id, CONCAT(first_name, ' ', last_name) as teacher_name
FROM Teacher
WHERE teacher_id NOT IN (SELECT teacher_id 
			 FROM Courses);
```
![image](https://github.com/user-attachments/assets/d1dd4e43-1c6f-4f37-91f2-7b0db55f7040)

 
7. Calculate the average age of all students. Use subqueries to calculate the age of each student based on their date of birth.
```sql
SELECT AVG(a.age) as AverageAgeOfAllStudents
FROM (SELECT DATEDIFF(YEAR, date_of_birth, GETDATE()) as age
      FROM Students) as a;
 ```
![image](https://github.com/user-attachments/assets/564dd860-678c-415b-8ac9-51210a912a07)


8. Identify courses with no enrollments. Use subqueries to find courses without enrollment records.

```sql
SELECT course_id, course_name
FROM Courses
WHERE course_id NOT IN (SELECT course_id
			FROM Enrollments);
```
![image](https://github.com/user-attachments/assets/144f68e4-b919-41d5-b67a-0ffe97488fd8)

 

9. Calculate the total payments made by each student for each course they are enrolled in. Use subqueries and aggregate functions to sum payments.
```sql
SELECT s.student_id, CONCAT(s.first_name, ' ', s.last_name) as student_name, SUM(p.amount) as total_payments
FROM Payments p, Students s
WHERE s.student_id = p.student_id
GROUP BY s.student_id, s.first_name, s.last_name;

```
![image](https://github.com/user-attachments/assets/9b82aa31-2c30-4de6-9792-8eb94c0bae7a)
 

10. Identify students who have made more than one payment. Use subqueries and aggregate functions to count payments per student and filter for those with counts greater than one.
```sql
SELECT student_id, CONCAT(first_name, ' ', last_name) as student_name
FROM Students
WHERE student_id IN (SELECT student_id
		     FROM Payments
		     GROUP BY student_id
		     HAVING COUNT(payment_id) > 1);
```

11. Write an SQL query to calculate the total payments made by each student. Join the "Students" table with the "Payments" table and use GROUP BY to calculate the sum of payments for each student.
```sql
SELECT s.student_id, CONCAT(s.first_name, ' ', s.last_name) as student_name, ISNULL(SUM(p.amount), 0) as total_payments
FROM Students s LEFT JOIN Payments p
ON s.student_id = p.student_id
GROUP BY s.student_id, s.first_name, s.last_name;
```
 ![image](https://github.com/user-attachments/assets/da9edf79-8b83-4e0e-bd4a-37ff1c79caee)


12. Retrieve a list of course names along with the count of students enrolled in each course. Use JOIN operations between the "Courses" table and the "Enrollments" table and GROUP BY to count enrollments.
```sql
SELECT c.course_id, c.course_name, ISNULL(COUNT(e.student_id), 0) as TotalEnrollments
FROM Courses c LEFT JOIN Enrollments e
ON c.course_id = e.course_id
GROUP BY c.course_id, c.course_name;
```
 ![image](https://github.com/user-attachments/assets/56026a40-3235-42e6-a0c4-7e9bf7ef0982)


13. Calculate the average payment amount made by students. Use JOIN operations between the "Students" table and the "Payments" table and GROUP BY to calculate the average.
```sql
SELECT s.student_id, CONCAT(s.first_name, ' ', s.last_name) as student_name, ISNULL(AVG(p.amount), 0) as AveragePaymentAmount
FROM Students s LEFT JOIN Payments p ON s.student_id = p.student_id
GROUP BY s.student_id, s.first_name, s.last_name;
```
![image](https://github.com/user-attachments/assets/40c25456-1b0f-426d-8dfe-4a9454bb8b54)
 
