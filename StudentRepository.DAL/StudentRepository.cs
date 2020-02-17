using System.Collections.Generic;
using StudentManagement.Entity;
namespace StudentManagement.DAL
{
    public class StudentRepository
    {
        public static List<StudentDetails> student = new List<StudentDetails>();
        static StudentRepository()
        {
            student.Add(new StudentDetails(1613179, "Rabish", "ECE"));
            student.Add(new StudentDetails(1613180, "Monisha", "CSE"));
            student.Add(new StudentDetails(1613179, "Saravanapriya", "IT"));
        }
        public IEnumerable<StudentDetails> GetStudentDetails()
        {
            return student;
        }
        public void AddStudent(StudentDetails studentDetails)
        {
            student.Add(studentDetails);
        }
        public StudentDetails GetStudentById(int studentId)
        {
            return student.Find(id => id.StudentId == studentId);
        }
        public void DeleteStudent(int studentId)
        {
            StudentDetails studentDetail = GetStudentById(studentId);
            if (studentDetail != null)
                student.Remove(studentDetail);
        }
        public void UpdateStudent(StudentDetails students)
        {
            StudentDetails student = GetStudentById(students.StudentId);
            student.StudentName = students.StudentName;
            student.StudentDept = students.StudentDept;
        }
    }
}
