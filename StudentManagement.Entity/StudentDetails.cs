
namespace StudentManagement.Entity
{
    public class StudentDetails
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentDept { get; set; }
        public StudentDetails(int studentId, string studentName, string studentDept)
        {
            StudentId = studentId;
            StudentName = studentName;
            StudentDept = studentDept;
        }
        public StudentDetails()
        {

        }
    }
}
