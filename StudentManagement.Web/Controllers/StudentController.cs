using System.Collections.Generic;
using System.Web.Mvc;
using StudentManagement.DAL;
using StudentManagement.Entity;

namespace StudentManagement.Web.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository student;
        public StudentController()
        {
            student = new StudentRepository();
        }
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<StudentDetails> students = student.GetStudentDetails();
            return View(students);
        }
        public ActionResult DataPassing()
        {
            IEnumerable<StudentDetails> students = student.GetStudentDetails();
            ViewBag.Student = students;
            ViewData["students"] = students;
            return View();
        }
        public ActionResult TempDataCheck()
        {
            IEnumerable<StudentDetails> studentDetails = student.GetStudentDetails();
            TempData["students"] = studentDetails;
            return RedirectToAction("TempDataChecking");
        }
        public ActionResult TempDataChecking()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult AddPackage()
        {
            StudentDetails studentDetails = new StudentDetails();
            UpdateModel(studentDetails);
            student.AddStudent(studentDetails);
            TempData["Message"] = "Student details added";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            StudentDetails studentDetails = student.GetStudentById(id);
            return View(studentDetails);
        }
        public ActionResult Delete(int id)
        {
            student.DeleteStudent(id);
            TempData["Message"] = "Student details deleted";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update()
        {
            StudentDetails studentDetails = new StudentDetails();
            TryUpdateModel(studentDetails);
            student.UpdateStudent(studentDetails);
            TempData["Message"] = "Student details updated";
            return RedirectToAction("Index");
        }
    }
}